using MfGames.Input;
using SK = Tao.Sdl.Sdl;

namespace BooGame.Sdl
{
	/// <summary>
	/// Encapsulates the mapping of SDL inputs to the input manager tokens.
	/// </summary>
	public static class SdlInputs
	{
		/// <summary>
		/// Maps the SDL keyboard codes into InputManager tokens.
		/// </summary>
		public static string MapInput(Tao.Sdl.Sdl.SDL_keysym key)
		{
			switch (key.sym)
			{
				// Basic Keys
				case SK.SDLK_a: return InputTokens.A;
				case SK.SDLK_b: return InputTokens.B;
				case SK.SDLK_c: return InputTokens.C;
				case SK.SDLK_d: return InputTokens.D;
				case SK.SDLK_e: return InputTokens.E;
				case SK.SDLK_f: return InputTokens.F;
				case SK.SDLK_g: return InputTokens.G;
				case SK.SDLK_h: return InputTokens.H;
				case SK.SDLK_i: return InputTokens.I;
				case SK.SDLK_j: return InputTokens.J;
				case SK.SDLK_k: return InputTokens.K;
				case SK.SDLK_l: return InputTokens.L;
				case SK.SDLK_m: return InputTokens.M;
				case SK.SDLK_n: return InputTokens.N;
				case SK.SDLK_o: return InputTokens.O;
				case SK.SDLK_p: return InputTokens.P;
				case SK.SDLK_q: return InputTokens.Q;
				case SK.SDLK_r: return InputTokens.R;
				case SK.SDLK_s: return InputTokens.S;
				case SK.SDLK_t: return InputTokens.T;
				case SK.SDLK_u: return InputTokens.U;
				case SK.SDLK_v: return InputTokens.V;
				case SK.SDLK_w: return InputTokens.W;
				case SK.SDLK_x: return InputTokens.X;
				case SK.SDLK_y: return InputTokens.Y;
				case SK.SDLK_z: return InputTokens.Z;

				case SK.SDLK_1: return InputTokens.D1;
				case SK.SDLK_2: return InputTokens.D2;
				case SK.SDLK_3: return InputTokens.D3;
				case SK.SDLK_4: return InputTokens.D4;
				case SK.SDLK_5: return InputTokens.D5;
				case SK.SDLK_6: return InputTokens.D6;
				case SK.SDLK_7: return InputTokens.D7;
				case SK.SDLK_8: return InputTokens.D8;
				case SK.SDLK_9: return InputTokens.D9;
				case SK.SDLK_0: return InputTokens.D0;

				case SK.SDLK_LEFT: return InputTokens.Left;
				case SK.SDLK_RIGHT: return InputTokens.Right;
				case SK.SDLK_UP: return InputTokens.Up;
				case SK.SDLK_DOWN: return InputTokens.Down;

				case SK.SDLK_RCTRL: return InputTokens.RightControl;
				case SK.SDLK_LCTRL: return InputTokens.LeftControl;
				case SK.SDLK_RSHIFT: return InputTokens.RightShift;
				case SK.SDLK_LSHIFT: return InputTokens.LeftShift;
				case SK.SDLK_RALT: return InputTokens.RightAlt;
				case SK.SDLK_LALT: return InputTokens.LeftAlt;

				case SK.SDLK_F1: return InputTokens.F1;
				case SK.SDLK_F2: return InputTokens.F2;
				case SK.SDLK_F3: return InputTokens.F3;
				case SK.SDLK_F4: return InputTokens.F4;
				case SK.SDLK_F5: return InputTokens.F5;
				case SK.SDLK_F6: return InputTokens.F6;
				case SK.SDLK_F7: return InputTokens.F7;
				case SK.SDLK_F8: return InputTokens.F8;
				case SK.SDLK_F9: return InputTokens.F9;
				case SK.SDLK_F10: return InputTokens.F10;
				case SK.SDLK_F11: return InputTokens.F11;
				case SK.SDLK_F12: return InputTokens.F12;

				case SK.SDLK_LEFTBRACKET: return InputTokens.OpenBracket;
				case SK.SDLK_RIGHTBRACKET: return InputTokens.CloseBracket;

				case SK.SDLK_ESCAPE: return InputTokens.Escape;
				case SK.SDLK_RETURN: return InputTokens.Enter;
				case SK.SDLK_NUMLOCK: return InputTokens.NumLock;
				case SK.SDLK_SPACE: return InputTokens.Space;

				case SK.SDLK_PERIOD: return InputTokens.Period;
				case SK.SDLK_COMMA: return InputTokens.Comma;

				case SK.SDLK_KP_ENTER: return InputTokens.NumPadEnter;
				case SK.SDLK_KP_PLUS: return InputTokens.NumPadAdd;
				case SK.SDLK_KP_MINUS: return InputTokens.NumPadSubtract;
				case SK.SDLK_KP_MULTIPLY: return InputTokens.NumPadMultiply;
				case SK.SDLK_KP_DIVIDE: return InputTokens.NumPadDivide;
				case SK.SDLK_KP0: return InputTokens.NumPad0;
				case SK.SDLK_KP1: return InputTokens.NumPad1;
				case SK.SDLK_KP2: return InputTokens.NumPad2;
				case SK.SDLK_KP3: return InputTokens.NumPad3;
				case SK.SDLK_KP4: return InputTokens.NumPad4;
				case SK.SDLK_KP5: return InputTokens.NumPad5;
				case SK.SDLK_KP6: return InputTokens.NumPad6;
				case SK.SDLK_KP7: return InputTokens.NumPad7;
				case SK.SDLK_KP8: return InputTokens.NumPad8;
				case SK.SDLK_KP9: return InputTokens.NumPad9;

				default:
					return null;
			}
		}
	}
}
