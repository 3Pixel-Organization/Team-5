// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputManager 1.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager1 : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager 1"",
    ""maps"": [
        {
            ""name"": ""MainController"",
            ""id"": ""6804769b-417c-4e46-ae97-722d0e728cec"",
            ""actions"": [
                {
                    ""name"": ""LMB"",
                    ""type"": ""Button"",
                    ""id"": ""d45e7773-d4b1-4810-b2ef-7a7d95223a42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RMB"",
                    ""type"": ""Button"",
                    ""id"": ""4afbbdb0-4683-408b-b566-8cfd903da03a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77b0d1f6-ab34-4362-9c5b-866607c53c0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Create"",
                    ""type"": ""PassThrough"",
                    ""id"": ""04f885bd-204e-49dc-8360-35c4b7711120"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""fc8db0ed-6bc8-4b00-a9c5-d88ea7d2e591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Load"",
                    ""type"": ""Button"",
                    ""id"": ""30199173-7152-4694-87d0-5415d6051a17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""50ce47ce-e825-42c6-a086-fb8d7b371002"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""b592ac18-5df6-46f9-994a-b3e491f20182"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MouseCameraMove"",
                    ""type"": ""Button"",
                    ""id"": ""cff5e8a4-2619-4d4e-9eaa-57a5902248fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e6e7577c-537a-4f73-a6a8-faa3fc19f7b1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ad9d4ed-50f5-4c3f-b608-04691e0841d8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7f1fe63-9879-4bce-b7d7-4bdf4238ff42"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""RMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c01c0bf-42b8-49f5-a385-eda6772be178"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f3bc5a6-5a24-4d16-bc89-fb73f72ce9bc"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Create"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bcb0483-bd6c-4321-babc-f6207cd01d70"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad4bfbe3-dcbe-4f88-8912-3747d87744c4"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Load"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f45db9b-fb5b-4df8-8806-b607e8d0ed4b"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c632c67-e84a-43e6-8196-74abd8bd4ea2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73d47ee1-4b46-4450-b251-f56ffac07d0e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""MouseCameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""faaa49be-b25d-421c-9c99-76e173659bdb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7cb146f5-991f-4abd-9272-fefb4504c251"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""23ae0e6a-4bb1-4c3a-bddb-d70ea478bd90"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3c9a874c-183e-4f63-aced-9e3a696d7b5f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5e96ae53-1e80-4ac6-b01d-4d5bc22a4038"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard And Mouse"",
            ""bindingGroup"": ""Keyboard And Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainController
        m_MainController = asset.FindActionMap("MainController", throwIfNotFound: true);
        m_MainController_LMB = m_MainController.FindAction("LMB", throwIfNotFound: true);
        m_MainController_RMB = m_MainController.FindAction("RMB", throwIfNotFound: true);
        m_MainController_MousePosition = m_MainController.FindAction("MousePosition", throwIfNotFound: true);
        m_MainController_Create = m_MainController.FindAction("Create", throwIfNotFound: true);
        m_MainController_Quit = m_MainController.FindAction("Quit", throwIfNotFound: true);
        m_MainController_Load = m_MainController.FindAction("Load", throwIfNotFound: true);
        m_MainController_Save = m_MainController.FindAction("Save", throwIfNotFound: true);
        m_MainController_Inventory = m_MainController.FindAction("Inventory", throwIfNotFound: true);
        m_MainController_MouseCameraMove = m_MainController.FindAction("MouseCameraMove", throwIfNotFound: true);
        m_MainController_Movement = m_MainController.FindAction("Movement", throwIfNotFound: true);
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

    // MainController
    private readonly InputActionMap m_MainController;
    private IMainControllerActions m_MainControllerActionsCallbackInterface;
    private readonly InputAction m_MainController_LMB;
    private readonly InputAction m_MainController_RMB;
    private readonly InputAction m_MainController_MousePosition;
    private readonly InputAction m_MainController_Create;
    private readonly InputAction m_MainController_Quit;
    private readonly InputAction m_MainController_Load;
    private readonly InputAction m_MainController_Save;
    private readonly InputAction m_MainController_Inventory;
    private readonly InputAction m_MainController_MouseCameraMove;
    private readonly InputAction m_MainController_Movement;
    public struct MainControllerActions
    {
        private @InputManager1 m_Wrapper;
        public MainControllerActions(@InputManager1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @LMB => m_Wrapper.m_MainController_LMB;
        public InputAction @RMB => m_Wrapper.m_MainController_RMB;
        public InputAction @MousePosition => m_Wrapper.m_MainController_MousePosition;
        public InputAction @Create => m_Wrapper.m_MainController_Create;
        public InputAction @Quit => m_Wrapper.m_MainController_Quit;
        public InputAction @Load => m_Wrapper.m_MainController_Load;
        public InputAction @Save => m_Wrapper.m_MainController_Save;
        public InputAction @Inventory => m_Wrapper.m_MainController_Inventory;
        public InputAction @MouseCameraMove => m_Wrapper.m_MainController_MouseCameraMove;
        public InputAction @Movement => m_Wrapper.m_MainController_Movement;
        public InputActionMap Get() { return m_Wrapper.m_MainController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMainControllerActions instance)
        {
            if (m_Wrapper.m_MainControllerActionsCallbackInterface != null)
            {
                @LMB.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLMB;
                @LMB.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLMB;
                @LMB.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLMB;
                @RMB.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRMB;
                @RMB.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRMB;
                @RMB.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRMB;
                @MousePosition.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMousePosition;
                @Create.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCreate;
                @Create.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCreate;
                @Create.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnCreate;
                @Quit.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnQuit;
                @Load.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLoad;
                @Load.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLoad;
                @Load.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnLoad;
                @Save.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnSave;
                @Inventory.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnInventory;
                @MouseCameraMove.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMouseCameraMove;
                @MouseCameraMove.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMouseCameraMove;
                @MouseCameraMove.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMouseCameraMove;
                @Movement.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_MainControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LMB.started += instance.OnLMB;
                @LMB.performed += instance.OnLMB;
                @LMB.canceled += instance.OnLMB;
                @RMB.started += instance.OnRMB;
                @RMB.performed += instance.OnRMB;
                @RMB.canceled += instance.OnRMB;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @Create.started += instance.OnCreate;
                @Create.performed += instance.OnCreate;
                @Create.canceled += instance.OnCreate;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Load.started += instance.OnLoad;
                @Load.performed += instance.OnLoad;
                @Load.canceled += instance.OnLoad;
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @MouseCameraMove.started += instance.OnMouseCameraMove;
                @MouseCameraMove.performed += instance.OnMouseCameraMove;
                @MouseCameraMove.canceled += instance.OnMouseCameraMove;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public MainControllerActions @MainController => new MainControllerActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard And Mouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IMainControllerActions
    {
        void OnLMB(InputAction.CallbackContext context);
        void OnRMB(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnCreate(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnLoad(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnMouseCameraMove(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
    }
}
