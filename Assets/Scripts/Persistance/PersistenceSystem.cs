using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SRS.DataPersistence
{
	public class PersistenceSystem : MonoBehaviour
	{
		public static PersistenceSystem Instance;

		[SerializeField] private bool encryptData;
		private readonly string encryptionKeyword = "Super secret encryption keyword";

		private DataHandler dataHandler;

		private DataSerializer serializer;

		private void Awake()
		{
			if(Instance == null)
			{
				Instance = this;
			}
			else if(Instance != this)
			{
				Destroy(this);
			}

			dataHandler = new FileDataHandler();
			serializer = new JsonDataSerializer();
		}

		private void Start()
		{
			Load("Save");
		}

		public void Save(string saveFile)
		{
			Debug.Log("Saving");
			Dictionary<string, object> state = new();
			CaptureState(state);
			
			string data = serializer.Serialize(state);

			Debug.Log(data);

			if(encryptData)
			{
				Debug.Log("encrypt");
				data = EncryptDecrypt(data);
			}

			dataHandler.Write(saveFile, data);
		}

		public void Load(string saveFile)
		{
			Debug.Log("Load");
			string data = dataHandler.Read(saveFile);

			if(string.IsNullOrEmpty(data))
			{
				return;
			}

			if(encryptData)
			{
				Debug.Log("decrypt");
				data = EncryptDecrypt(data);
			}

			Debug.Log(data);

			Dictionary<string, object> state = serializer.Deserialize(data);

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
			if(state == null)
			{
				Debug.Log("Null");
				return;
			}

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