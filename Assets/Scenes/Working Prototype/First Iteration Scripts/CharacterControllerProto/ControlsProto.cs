//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Scenes/Working Prototype/First Iteration Scripts/CharacterControllerProto/ControlsProto.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlsProto : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsProto()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsProto"",
    ""maps"": [
        {
            ""name"": ""Avatar Controls"",
            ""id"": ""e2441064-d46f-46a4-95e9-611bed67485d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""584645b3-02ae-460e-a35f-e1e57aa3b06c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""9835b75d-574f-4e51-80ba-bf43a1087745"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Value"",
                    ""id"": ""32839c98-a487-4526-b3b9-90551e09c59e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""cfaf3049-f06a-4143-9411-b9d7bb2e8a3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""862b317e-6c66-4363-8347-2d306ac6dfb2"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5d6a2e2-22bb-42c1-8d01-6a07f2542de5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35795f60-6b3d-40d5-abb5-e00266b12cd9"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6595c731-2472-47dd-8f0e-101fdc3f4ed3"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34fbef37-863c-40ff-9e8a-35947ed00037"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0524d193-8ce3-4222-9b76-5bc663a3f4b9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29ce5646-228f-46b7-b580-60d88d5b6821"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f54e7566-021d-4f2f-a9b9-cc80e5cfa204"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fd1b6003-63e5-4236-8376-e98b594d7aee"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1f28706-45e7-4a28-b923-c69f2da658df"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""264444c7-830f-4786-82e2-48020d529d26"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3e41371d-007f-4c21-8a1a-4b1ff86ed83a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB+M"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eb047709-288e-4c7c-bb52-23673ff00e84"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB+M"",
            ""bindingGroup"": ""KB+M"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Avatar Controls
        m_AvatarControls = asset.FindActionMap("Avatar Controls", throwIfNotFound: true);
        m_AvatarControls_Move = m_AvatarControls.FindAction("Move", throwIfNotFound: true);
        m_AvatarControls_Look = m_AvatarControls.FindAction("Look", throwIfNotFound: true);
        m_AvatarControls_Attack = m_AvatarControls.FindAction("Attack", throwIfNotFound: true);
        m_AvatarControls_Ability = m_AvatarControls.FindAction("Ability", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Avatar Controls
    private readonly InputActionMap m_AvatarControls;
    private IAvatarControlsActions m_AvatarControlsActionsCallbackInterface;
    private readonly InputAction m_AvatarControls_Move;
    private readonly InputAction m_AvatarControls_Look;
    private readonly InputAction m_AvatarControls_Attack;
    private readonly InputAction m_AvatarControls_Ability;
    public struct AvatarControlsActions
    {
        private @ControlsProto m_Wrapper;
        public AvatarControlsActions(@ControlsProto wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_AvatarControls_Move;
        public InputAction @Look => m_Wrapper.m_AvatarControls_Look;
        public InputAction @Attack => m_Wrapper.m_AvatarControls_Attack;
        public InputAction @Ability => m_Wrapper.m_AvatarControls_Ability;
        public InputActionMap Get() { return m_Wrapper.m_AvatarControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AvatarControlsActions set) { return set.Get(); }
        public void SetCallbacks(IAvatarControlsActions instance)
        {
            if (m_Wrapper.m_AvatarControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnLook;
                @Attack.started -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAttack;
                @Ability.started -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAbility;
                @Ability.performed -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAbility;
                @Ability.canceled -= m_Wrapper.m_AvatarControlsActionsCallbackInterface.OnAbility;
            }
            m_Wrapper.m_AvatarControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Ability.started += instance.OnAbility;
                @Ability.performed += instance.OnAbility;
                @Ability.canceled += instance.OnAbility;
            }
        }
    }
    public AvatarControlsActions @AvatarControls => new AvatarControlsActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KB+M");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IAvatarControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnAbility(InputAction.CallbackContext context);
    }
}
