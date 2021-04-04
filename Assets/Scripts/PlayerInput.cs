// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerTank"",
            ""id"": ""c942c761-5857-4928-9760-dc8a6988b0ff"",
            ""actions"": [
                {
                    ""name"": ""MoveTank"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8314baed-638a-404e-931c-9c08601cc410"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""ShootMain"",
                    ""type"": ""Button"",
                    ""id"": ""49e80c67-b113-415a-94e1-c0560155e486"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1c7fd71e-80f0-434b-a428-6d0d2b4f90ab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootHoming"",
                    ""type"": ""Button"",
                    ""id"": ""709c2369-3d49-4b6d-ac10-eca2137a0657"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bbafc4b9-07c3-4f40-8a3b-3440742b6fb2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTank"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf1fdaa9-62d6-4a5e-baf1-d9fc1f90fa1b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c55506e-419e-4b45-90f2-2c590ed09fbc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""090afcf9-0b62-4387-9634-5eb1db579a08"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02d2f974-9b05-44ae-8433-d0dfd5fe0e7d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e5731f35-b3fc-4157-9bfc-58d45a33cf14"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""SlowTap"",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""ShootMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab019042-9b1f-4e06-9a53-c32ede2b0bdc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7524e42b-9a6e-4d56-ac8a-1e84d10e00a3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""SlowTap"",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""ShootHoming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerTank
        m_PlayerTank = asset.FindActionMap("PlayerTank", throwIfNotFound: true);
        m_PlayerTank_MoveTank = m_PlayerTank.FindAction("MoveTank", throwIfNotFound: true);
        m_PlayerTank_ShootMain = m_PlayerTank.FindAction("ShootMain", throwIfNotFound: true);
        m_PlayerTank_Aim = m_PlayerTank.FindAction("Aim", throwIfNotFound: true);
        m_PlayerTank_ShootHoming = m_PlayerTank.FindAction("ShootHoming", throwIfNotFound: true);
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

    // PlayerTank
    private readonly InputActionMap m_PlayerTank;
    private IPlayerTankActions m_PlayerTankActionsCallbackInterface;
    private readonly InputAction m_PlayerTank_MoveTank;
    private readonly InputAction m_PlayerTank_ShootMain;
    private readonly InputAction m_PlayerTank_Aim;
    private readonly InputAction m_PlayerTank_ShootHoming;
    public struct PlayerTankActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerTankActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveTank => m_Wrapper.m_PlayerTank_MoveTank;
        public InputAction @ShootMain => m_Wrapper.m_PlayerTank_ShootMain;
        public InputAction @Aim => m_Wrapper.m_PlayerTank_Aim;
        public InputAction @ShootHoming => m_Wrapper.m_PlayerTank_ShootHoming;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTank; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTankActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTankActions instance)
        {
            if (m_Wrapper.m_PlayerTankActionsCallbackInterface != null)
            {
                @MoveTank.started -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnMoveTank;
                @MoveTank.performed -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnMoveTank;
                @MoveTank.canceled -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnMoveTank;
                @ShootMain.started -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootMain;
                @ShootMain.performed -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootMain;
                @ShootMain.canceled -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootMain;
                @Aim.started -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnAim;
                @ShootHoming.started -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootHoming;
                @ShootHoming.performed -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootHoming;
                @ShootHoming.canceled -= m_Wrapper.m_PlayerTankActionsCallbackInterface.OnShootHoming;
            }
            m_Wrapper.m_PlayerTankActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveTank.started += instance.OnMoveTank;
                @MoveTank.performed += instance.OnMoveTank;
                @MoveTank.canceled += instance.OnMoveTank;
                @ShootMain.started += instance.OnShootMain;
                @ShootMain.performed += instance.OnShootMain;
                @ShootMain.canceled += instance.OnShootMain;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @ShootHoming.started += instance.OnShootHoming;
                @ShootHoming.performed += instance.OnShootHoming;
                @ShootHoming.canceled += instance.OnShootHoming;
            }
        }
    }
    public PlayerTankActions @PlayerTank => new PlayerTankActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPlayerTankActions
    {
        void OnMoveTank(InputAction.CallbackContext context);
        void OnShootMain(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShootHoming(InputAction.CallbackContext context);
    }
}
