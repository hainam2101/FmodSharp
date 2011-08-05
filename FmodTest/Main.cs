using System;

namespace FmodTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Sound Test");
			
#if DEBUG
			
#else
			FmodSharp.Debug.Level = FmodSharp.DebugLevel.Error;
#endif
			
			Console.WriteLine ("Level: {0}", FmodSharp.Debug.Level);
			Console.WriteLine ("Type: {0}", FmodSharp.Debug.Type);
			Console.WriteLine ("Display: {0}", FmodSharp.Debug.Display);
			
			FmodSharp.SoundSystem.SoundSystem  SoundSystem = new FmodSharp.SoundSystem.SoundSystem();
			
			Console.WriteLine ("Default Output Type: {0}", SoundSystem.Output);
			
			SoundSystem.Init();
			
			FmodSharp.Channel.Channel Chan = null;
			
			//Create an oscillator DSP unit for the tone.
			FmodSharp.Dsp.Dsp Oscillator;
			
			Oscillator = SoundSystem.CreateDspByType(FmodSharp.Dsp.Type.Oscillator);
			Chan = SoundSystem.PlayDsp(Oscillator);
			
			Console.WriteLine("\nPress Enter to stop.\n");
			bool Quit = false;
			while(!Quit) {
				switch (Console.ReadKey().Key) {
				
				case ConsoleKey.Enter:
				case ConsoleKey.Escape:
					Quit = true;
					break;
				
					//Change note
				case ConsoleKey.LeftArrow :
					//Oscillator.setParameter((int)FMOD.DSP_OSCILLATOR.RATE, 440.0f);
					break;
					
				case ConsoleKey.RightArrow:
					//Oscillator.setParameter((int)FMOD.DSP_OSCILLATOR.RATE, 440.0f);
					break;
					
					//Change Volume
				case ConsoleKey.UpArrow:
					Chan.Volume += 0.05f;
					break;
					
				case ConsoleKey.DownArrow:
					Chan.Volume -= 0.05f;
					break;
					
					//Change Tone
				case ConsoleKey.Spacebar:
					//dsp.setParameter((int)FMOD.DSP_OSCILLATOR.TYPE, 0);
					//channel.setPaused(false);
					break;
					
				default:
					break;
				}
				
				System.Threading.Thread.Sleep(10);
			}
			Chan.Dispose();
			SoundSystem.CloseSystem();
			SoundSystem.Dispose();
		}
	}
}

