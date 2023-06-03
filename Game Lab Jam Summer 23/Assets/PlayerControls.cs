//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Character"",
            ""id"": ""aed70464-1fe6-46c0-849b-924f1f8e8927"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""824e191e-c2c1-4fb1-b1c3-9e10799a13a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Grab Left"",
                    ""type"": ""Button"",
                    ""id"": ""4fa2ce31-c5e7-4a27-9e37-755ad2444a63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab Right"",
                    ""type"": ""Button"",
                    ""id"": ""641454e7-0287-4dc7-b0af-4477b8f208b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Smash"",
                    ""type"": ""Button"",
                    ""id"": ""b53514f9-dff4-4f48-a620-8e7280ab13ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""f142573a-23fe-4328-aa3e-bef3ef8feb8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bb520126-bf75-45bd-93b4-3b4500c2a9c6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e22ef1f5-67da-4c64-b406-02923cb59410"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Smash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d4ab407-e289-41c2-9256-9f5d06fee717"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e51afee3-d7f0-48be-9b66-67a48dec5ec9"",
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
                    ""id"": ""21765563-522f-42d0-9305-98893a3f22a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""802734cb-2d90-4589-a9b4-e894bffb7dba"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c7040e9-6820-40ee-9cbe-11fce48e4688"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d6982b53-205e-4d27-98d4-9f49a1bca56b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ff9f13f7-fd51-4e18-9f00-d96a95218d3c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Character
        m_PlayerCharacter = asset.FindActionMap("Player Character", throwIfNotFound: true);
        m_PlayerCharacter_Movement = m_PlayerCharacter.FindAction("Movement", throwIfNotFound: true);
        m_PlayerCharacter_GrabLeft = m_PlayerCharacter.FindAction("Grab Left", throwIfNotFound: true);
        m_PlayerCharacter_GrabRight = m_PlayerCharacter.FindAction("Grab Right", throwIfNotFound: true);
        m_PlayerCharacter_Smash = m_PlayerCharacter.FindAction("Smash", throwIfNotFound: true);
        m_PlayerCharacter_CameraMovement = m_PlayerCharacter.FindAction("CameraMovement", throwIfNotFound: true);
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

    // Player Character
    private readonly InputActionMap m_PlayerCharacter;
    private List<IPlayerCharacterActions> m_PlayerCharacterActionsCallbackInterfaces = new List<IPlayerCharacterActions>();
    private readonly InputAction m_PlayerCharacter_Movement;
    private readonly InputAction m_PlayerCharacter_GrabLeft;
    private readonly InputAction m_PlayerCharacter_GrabRight;
    private readonly InputAction m_PlayerCharacter_Smash;
    private readonly InputAction m_PlayerCharacter_CameraMovement;
    public struct PlayerCharacterActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerCharacterActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerCharacter_Movement;
        public InputAction @GrabLeft => m_Wrapper.m_PlayerCharacter_GrabLeft;
        public InputAction @GrabRight => m_Wrapper.m_PlayerCharacter_GrabRight;
        public InputAction @Smash => m_Wrapper.m_PlayerCharacter_Smash;
        public InputAction @CameraMovement => m_Wrapper.m_PlayerCharacter_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCharacter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCharacterActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerCharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerCharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerCharacterActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @GrabLeft.started += instance.OnGrabLeft;
            @GrabLeft.performed += instance.OnGrabLeft;
            @GrabLeft.canceled += instance.OnGrabLeft;
            @GrabRight.started += instance.OnGrabRight;
            @GrabRight.performed += instance.OnGrabRight;
            @GrabRight.canceled += instance.OnGrabRight;
            @Smash.started += instance.OnSmash;
            @Smash.performed += instance.OnSmash;
            @Smash.canceled += instance.OnSmash;
            @CameraMovement.started += instance.OnCameraMovement;
            @CameraMovement.performed += instance.OnCameraMovement;
            @CameraMovement.canceled += instance.OnCameraMovement;
        }

        private void UnregisterCallbacks(IPlayerCharacterActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @GrabLeft.started -= instance.OnGrabLeft;
            @GrabLeft.performed -= instance.OnGrabLeft;
            @GrabLeft.canceled -= instance.OnGrabLeft;
            @GrabRight.started -= instance.OnGrabRight;
            @GrabRight.performed -= instance.OnGrabRight;
            @GrabRight.canceled -= instance.OnGrabRight;
            @Smash.started -= instance.OnSmash;
            @Smash.performed -= instance.OnSmash;
            @Smash.canceled -= instance.OnSmash;
            @CameraMovement.started -= instance.OnCameraMovement;
            @CameraMovement.performed -= instance.OnCameraMovement;
            @CameraMovement.canceled -= instance.OnCameraMovement;
        }

        public void RemoveCallbacks(IPlayerCharacterActions instance)
        {
            if (m_Wrapper.m_PlayerCharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerCharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerCharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerCharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerCharacterActions @PlayerCharacter => new PlayerCharacterActions(this);
    public interface IPlayerCharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnGrabLeft(InputAction.CallbackContext context);
        void OnGrabRight(InputAction.CallbackContext context);
        void OnSmash(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
}
