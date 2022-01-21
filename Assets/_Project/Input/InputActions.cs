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
                    ""type"": ""PassThrough"",
                    ""id"": ""c0e6600a-a849-468a-9350-6c989099fda9"",
                    ""expectedControlType"": ""Axis"",
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
                    ""name"": ""ad"",
                    ""id"": ""0541fb82-0e0e-4f03-bb41-ee72dc30ca5d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""62959dc6-0bb4-4488-a730-37763eb96ec1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6de58cc5-69ea-4de4-a4cd-34977afd25b1"",
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
            ""id"": ""ac0d152d-3bca-470a-955a-44c3f2a440ec"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f3c385e0-aacb-43d9-818f-54633618edcc"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f11179b3-7b78-4b32-8286-0ec936fcd479"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""arrow"",
                    ""id"": ""2cc712c8-0abe-494a-a50c-40680a997a17"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""333accca-3d7c-4ad1-a185-38de733d54b1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""451e12aa-9f26-4117-a942-741c2aa121ad"",
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
                    ""id"": ""917e75ae-f4f5-4607-ad51-d832a8a0b188"",
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
    ""controlSchemes"": [
        {
            ""name"": ""P1"",
            ""bindingGroup"": ""P1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""P2"",
            ""bindingGroup"": ""P2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
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
        private int m_P1SchemeIndex = -1;
        public InputControlScheme P1Scheme
        {
            get
            {
                if (m_P1SchemeIndex == -1) m_P1SchemeIndex = asset.FindControlSchemeIndex("P1");
                return asset.controlSchemes[m_P1SchemeIndex];
            }
        }
        private int m_P2SchemeIndex = -1;
        public InputControlScheme P2Scheme
        {
            get
            {
                if (m_P2SchemeIndex == -1) m_P2SchemeIndex = asset.FindControlSchemeIndex("P2");
                return asset.controlSchemes[m_P2SchemeIndex];
            }
        }
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
