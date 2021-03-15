// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Input/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""ThirdPerson"",
            ""id"": ""2c4a876c-cee2-402a-bd2f-e2c9024f9f49"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""41c53ad8-3d15-425c-af00-21d044776ad3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""fd254192-865b-4617-8c98-9e50a2fecbde"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""41dc0ecf-dfab-4ffc-a619-4e59001b7236"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""EquipBow"",
                    ""type"": ""Button"",
                    ""id"": ""dd3cf0f3-1776-4823-8c8c-69a92b659fe4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""359ca8db-0ca0-4f3b-bffe-ad5fc6a27b3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""9f5a7355-dc3e-47f9-987a-197815da8e09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ef9e9d98-fa48-4fb8-831d-374c38bb7423"",
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
                    ""id"": ""8370224b-b078-4463-b4a7-b342993741e8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""77c4e031-0231-40a3-a979-1fb0e8c86ea5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f00e8924-404d-459c-8a2f-816c1010d337"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f451dd7-8430-42e8-9cb7-f546dc4d95c4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""df4c88d2-a4f0-406d-a73f-a0b7d6e10983"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b703dd16-d8ad-425f-bbc8-a7ae797cade6"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b6819a2-142e-4c39-b7bc-317ef349ed91"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EquipBow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6762c01-b650-4f2b-8f23-ebb234ef62bd"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38535735-db0a-4803-8ad4-f28d10bd59d7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ThirdPerson
        m_ThirdPerson = asset.FindActionMap("ThirdPerson", throwIfNotFound: true);
        m_ThirdPerson_Move = m_ThirdPerson.FindAction("Move", throwIfNotFound: true);
        m_ThirdPerson_Look = m_ThirdPerson.FindAction("Look", throwIfNotFound: true);
        m_ThirdPerson_Run = m_ThirdPerson.FindAction("Run", throwIfNotFound: true);
        m_ThirdPerson_EquipBow = m_ThirdPerson.FindAction("EquipBow", throwIfNotFound: true);
        m_ThirdPerson_Aim = m_ThirdPerson.FindAction("Aim", throwIfNotFound: true);
        m_ThirdPerson_Attack = m_ThirdPerson.FindAction("Attack", throwIfNotFound: true);
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

    // ThirdPerson
    private readonly InputActionMap m_ThirdPerson;
    private IThirdPersonActions m_ThirdPersonActionsCallbackInterface;
    private readonly InputAction m_ThirdPerson_Move;
    private readonly InputAction m_ThirdPerson_Look;
    private readonly InputAction m_ThirdPerson_Run;
    private readonly InputAction m_ThirdPerson_EquipBow;
    private readonly InputAction m_ThirdPerson_Aim;
    private readonly InputAction m_ThirdPerson_Attack;
    public struct ThirdPersonActions
    {
        private @GameInputActions m_Wrapper;
        public ThirdPersonActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ThirdPerson_Move;
        public InputAction @Look => m_Wrapper.m_ThirdPerson_Look;
        public InputAction @Run => m_Wrapper.m_ThirdPerson_Run;
        public InputAction @EquipBow => m_Wrapper.m_ThirdPerson_EquipBow;
        public InputAction @Aim => m_Wrapper.m_ThirdPerson_Aim;
        public InputAction @Attack => m_Wrapper.m_ThirdPerson_Attack;
        public InputActionMap Get() { return m_Wrapper.m_ThirdPerson; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ThirdPersonActions set) { return set.Get(); }
        public void SetCallbacks(IThirdPersonActions instance)
        {
            if (m_Wrapper.m_ThirdPersonActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnLook;
                @Run.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnRun;
                @EquipBow.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnEquipBow;
                @EquipBow.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnEquipBow;
                @EquipBow.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnEquipBow;
                @Aim.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAim;
                @Attack.started -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ThirdPersonActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_ThirdPersonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @EquipBow.started += instance.OnEquipBow;
                @EquipBow.performed += instance.OnEquipBow;
                @EquipBow.canceled += instance.OnEquipBow;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public ThirdPersonActions @ThirdPerson => new ThirdPersonActions(this);
    public interface IThirdPersonActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnEquipBow(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
