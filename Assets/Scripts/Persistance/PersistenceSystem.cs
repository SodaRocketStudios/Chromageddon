using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SRS.DataPersistence
{
	public class PersistenceSystem : MonoBehaviour
	{
		[SerializeField] private bool encryptData;
		private readonly string encryptionKeyword = "Super secret encryption keyword";

		private DataHandler dataHandler;

		private DataSerializer serializer;

		private void Awake()
		{
			dataHandler = new FileDataHandler();
			serializer = new JsonDataSerializer();
		}

		public void Save(string saveFile)
		{
			Dictionary<string, object> state = new();
			CaptureState(state);
			
			string data = serializer.Serialize(state);

			if(encryptData)
			{
				data = EncryptDecrypt(data);
			}

			dataHandler.Write(saveFile, data);
		}

		public void Load(string saveFile)
		{
			string data = dataHandler.Read(saveFile);

			if(encryptData)
			{
				data = EncryptDecrypt(data);
			}

			Dictionary<string, object> state = serializer.Deserialize(data) as Dictionary<string, object>;

			RestoreState(state);
		}

		private void CaptureState(Dictionary<string, object> state)
		{
			foreach(PersistentEntity entity in FindObjectsByType<PersistentEntity>(FindObjectsSortMode.None))
			{
				state[entity.UniqueIdentifier] = entity.CaptureState();
			}
		}

		private void RestoreState(Dictionary<string, object> state)
		{
			foreach(PersistentEntity entity in FindObjectsByType<PersistentEntity>(FindObjectsSortMode.None))
			{
				if(state.ContainsKey(entity.UniqueIdentifier))
				{
					entity.RestoreState(state[entity.UniqueIdentifier]);
				}
			}
		}

		private string EncryptDecrypt(string data)
		{
			StringBuilder dataBuilder = new();

			for(int i = 0; i < data.Length; i++)
			{
				dataBuilder.Append(data[i] ^ encryptionKeyword[i % encryptionKeyword.Length]);
			}

			return dataBuilder.ToString();
		}
	}
}