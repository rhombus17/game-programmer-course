// GENERATED AUTOMATICALLY FROM 'Assets/_Project/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TutInput
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""P1"",
            ""id"": ""a0577b4e-b76e-406d-9d03-bafabe1f7508"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c0e6600a-a849-468a-9350-6c989099fda9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3d199e5a-11bc-45a2-9e35-06e452126c04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""14e00330-f867-4674-85e1-754f274a26ad"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""ea79b74e-3340-49e8-9f2c-204230d3323e"",
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
                    ""id"": ""606d0daf-03dc-4046-a68b-ce389d3f71af"",
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
                    ""id"": ""544209a1-7722-49cf-80fb-aadf56ae32f8"",
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
                    ""id"": ""58794eef-072c-4986-b0f4-5faf399cf2c7"",
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
                    ""id"": ""ecba0774-2fa2-4714-ab6f-acdf607acc67"",
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
                    ""id"": ""0eedc3c7-84e0-40a9-ba1d-2cb0c26f2236"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b41432d-abfc-496c-bc15-7580d96fe161"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""P2"",
            ""id"": ""b6811866-4892-4f38-847e-f2285dc0dc58"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""53b21080-5409-4289-ba7e-7e0f793869da"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""78c5ea10-7f44-4317-b18a-f89aa0c2700f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ec37e296-646b-446f-8144-9499cb5a5bfd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""04b32a1a-eb36-4e93-8d8d-d4cab74a99f6"",
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
                    ""id"": ""791f74c2-e71a-40f0-8cdf-9eb4c78473a6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9259231d-52ca-4563-abd1-492e9805e300"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f66f6258-f619-4d3b-82f3-f25e546b42b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6dd6dc63-9c0b-4472-9df8-e0542c6e56c8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0aca913a-6ddb-4d7c-8ef5-2e1dd234acc7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4e5a91a-46e2-448d-b126-962e14646c71"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // P1
            m_P1 = asset.FindActionMap("P1", throwIfNotFound: true);
            m_P1_Move = m_P1.FindAction("Move", throwIfNotFound: true);
            m_P1_Jump = m_P1.FindAction("Jump", throwIfNotFound: true);
            // P2
            m_P2 = asset.FindActionMap("P2", throwIfNotFound: true);
            m_P2_Move = m_P2.FindAction("Move", throwIfNotFound: true);
            m_P2_Jump = m_P2.FindAction("Jump", throwIfNotFound: true);
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

        // P1
        private readonly InputActionMap m_P1;
        private IP1Actions m_P1ActionsCallbackInterface;
        private readonly InputAction m_P1_Move;
        private readonly InputAction m_P1_Jump;
        public struct P1Actions
        {
            private @InputActions m_Wrapper;
            public P1Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_P1_Move;
            public InputAction @Jump => m_Wrapper.m_P1_Jump;
            public InputActionMap Get() { return m_Wrapper.m_P1; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(P1Actions set) { return set.Get(); }
            public void SetCallbacks(IP1Actions instance)
            {
                if (m_Wrapper.m_P1ActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_P1ActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_P1ActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_P1ActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_P1ActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_P1ActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_P1ActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_P1ActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public P1Actions @P1 => new P1Actions(this);

        // P2
        private readonly InputActionMap m_P2;
        private IP2Actions m_P2ActionsCallbackInterface;
        private readonly InputAction m_P2_Move;
        private readonly InputAction m_P2_Jump;
        public struct P2Actions
        {
            private @InputActions m_Wrapper;
            public P2Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_P2_Move;
            public InputAction @Jump => m_Wrapper.m_P2_Jump;
            public InputActionMap Get() { return m_Wrapper.m_P2; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(P2Actions set) { return set.Get(); }
            public void SetCallbacks(IP2Actions instance)
            {
                if (m_Wrapper.m_P2ActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnMove;
                    @Jump.started -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_P2ActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_P2ActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public P2Actions @P2 => new P2Actions(this);
        public interface IP1Actions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IP2Actions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
    }
}
