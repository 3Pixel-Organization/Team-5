// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Input
{

	public class @InputSystem : IInputActionCollection, IDisposable
	{
		public InputActionAsset asset { get; }
		public @InputSystem()
		{
			asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""1649ebc2-c01a-419d-872a-c5aaa3b7a1d3"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6cb25954-7bed-4ee3-b407-9e209cc9ea38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cbfdd561-c293-45e5-bc82-3fe8459594cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LMB"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6fba7118-7f7b-405a-a74c-47dd551d1cdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""mousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9509eab7-4a8b-4c17-93fe-7dd2d735a786"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""4123ee63-c870-44f1-baa7-fe884b257314"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6ede2a9e-975c-4d10-9781-dcc1e4569a94"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""537ce5e9-4320-479d-973e-039977f1696f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5e61c9e1-8447-43c1-9179-fd4fc0189289"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7bf87ee-8d13-4e4e-9277-d5039ea5b6cf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9bf1286-296c-4c2f-908f-8498b4099479"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
			// player
			m_player = asset.FindActionMap("player", throwIfNotFound: true);
			m_player_move = m_player.FindAction("move", throwIfNotFound: true);
			m_player_jump = m_player.FindAction("jump", throwIfNotFound: true);
			m_player_LMB = m_player.FindAction("LMB", throwIfNotFound: true);
			m_player_mousePosition = m_player.FindAction("mousePosition", throwIfNotFound: true);
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

		// player
		private readonly InputActionMap m_player;
		private IPlayerActions m_PlayerActionsCallbackInterface;
		private readonly InputAction m_player_move;
		private readonly InputAction m_player_jump;
		private readonly InputAction m_player_LMB;
		private readonly InputAction m_player_mousePosition;
		public struct PlayerActions
		{
			private @InputSystem m_Wrapper;
			public PlayerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
			public InputAction @move => m_Wrapper.m_player_move;
			public InputAction @jump => m_Wrapper.m_player_jump;
			public InputAction @LMB => m_Wrapper.m_player_LMB;
			public InputAction @mousePosition => m_Wrapper.m_player_mousePosition;
			public InputActionMap Get() { return m_Wrapper.m_player; }
			public void Enable() { Get().Enable(); }
			public void Disable() { Get().Disable(); }
			public bool enabled => Get().enabled;
			public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
			public void SetCallbacks(IPlayerActions instance)
			{
				if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
				{
					@move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
					@jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
					@jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
					@jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
					@LMB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLMB;
					@LMB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLMB;
					@LMB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLMB;
					@mousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
					@mousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
					@mousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
				}
				m_Wrapper.m_PlayerActionsCallbackInterface = instance;
				if (instance != null)
				{
					@move.started += instance.OnMove;
					@move.performed += instance.OnMove;
					@move.canceled += instance.OnMove;
					@jump.started += instance.OnJump;
					@jump.performed += instance.OnJump;
					@jump.canceled += instance.OnJump;
					@LMB.started += instance.OnLMB;
					@LMB.performed += instance.OnLMB;
					@LMB.canceled += instance.OnLMB;
					@mousePosition.started += instance.OnMousePosition;
					@mousePosition.performed += instance.OnMousePosition;
					@mousePosition.canceled += instance.OnMousePosition;
				}
			}
		}
		public PlayerActions @player => new PlayerActions(this);
		public interface IPlayerActions
		{
			void OnMove(InputAction.CallbackContext context);
			void OnJump(InputAction.CallbackContext context);
			void OnLMB(InputAction.CallbackContext context);
			void OnMousePosition(InputAction.CallbackContext context);
		}
	}

}
