using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SDL2;

namespace SDL_Game_of_Life_CS_Port
{
    class GameOfLife
    {
		private IntPtr _window;
		private IntPtr _renderer;

		private IntPtr _playPauseButton;
		private IntPtr _stopButton;
		private IntPtr _advanceButton;
		private IntPtr _clearButton;
		private IntPtr _quitButton;

		private SDL.SDL_Rect _generationLabelPos;

		private SDL.SDL_Event _event;

		private IntPtr _textFont;

		private int _gridWidth;
		private int _gridHeight;
		private int _cellSize;
		private uint _delay;
		private string _rules;
		private int _margin;

		private int _generationCount;

		private Point _mouseClickPos;
		private bool _leftClick;
		private bool _clicked;
		private bool _holding;

		private bool _running;
		private bool _settingUp;
		private bool _wrap;

		private bool _stopped;
		private bool _paused;
		private bool _suspended;
		private bool _advance;

		private bool[,] _grid;
		private bool[,] _startGrid;

		private List<int> _bornNums;
		private List<int> _aliveNums;

		public GameOfLife(int width, int height, int cellSize, uint delay, string rules, bool wrap)//, BlockingCollection<GOL_Message> bc)
		{
			// Initialize SDL
			SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
			SDL_ttf.TTF_Init();

			// Initialize members
			_gridWidth = width;
			_gridHeight = height;
			_cellSize = cellSize;
			_delay = delay;

			this._initCommon();

			int windowWidth = _gridWidth * (_cellSize + 1) - 1;
			if (windowWidth < _generationLabelPos.x + _generationLabelPos.w + 10)
			{
				windowWidth = _generationLabelPos.x + _generationLabelPos.w + 10;
			}

			_window = SDL.SDL_CreateWindow("Conway's Game of Life", SDL.SDL_WINDOWPOS_CENTERED_DISPLAY(0), 30, windowWidth, _gridHeight * (_cellSize + 1) - 1 + _margin, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
			_renderer = SDL.SDL_CreateRenderer(_window, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

			_wrap = wrap;

			_bornNums = new List<int>();
			_aliveNums = new List<int>();

			_rules = rules;

			int stringIter = 0;
			while (true)
			{
				if (rules[stringIter] == 'B' || rules[stringIter] == 'b')
				{
					stringIter++;
					continue;
				}
				else if (rules[stringIter] == '/')
				{
					stringIter += 2;
					break;
				}
				else
				{
					_bornNums.Add(rules[stringIter] - '0');
				}

				stringIter++;
			}
			while (true)
			{
				if (stringIter == rules.Length) break;

				_aliveNums.Add(rules[stringIter] - '0');
				stringIter++;
			}
		}

		public GameOfLife(uint delay, bool wrap, GOL_PRESET preset)
		{
			// Initialize SDL
			SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
			SDL_ttf.TTF_Init();

			// Initialize members
			_gridWidth = 75;
			_gridHeight = 75;
			_cellSize = 5;
			_delay = delay;
			this._initCommon();

			_window = SDL.SDL_CreateWindow("Conway's Game of Life", SDL.SDL_WINDOWPOS_CENTERED, 30, _gridWidth * (_cellSize + 1) - 1, _gridHeight * (_cellSize + 1) - 1 + _margin, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
			_renderer = SDL.SDL_CreateRenderer(_window, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

			_wrap = wrap;
			this._initDefaultGOL(preset);

			string rules = "B3/S23";
			_rules = rules;

			_bornNums = new List<int>();
			_aliveNums = new List<int>();

			int stringIter = 0;
			while (true)
			{
				if (rules[stringIter] == 'B' || rules[stringIter] == 'b')
				{
					stringIter++;
					continue;
				}
				else if (rules[stringIter] == '/')
				{
					stringIter += 2;
					break;
				}
				else
				{
					_bornNums.Add(rules[stringIter] - '0');
				}

				stringIter++;
			}
			while (true)
			{
				if (stringIter == rules.Length) break;

				_aliveNums.Add(rules[stringIter] - '0');
				stringIter++;
			}
		}

		public GameOfLife(uint delay, bool wrap, HL_PRESET preset)
		{
			// Initialize SDL
			SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
			SDL_ttf.TTF_Init();

			// Initialize members
			_gridWidth = 75;
			_gridHeight = 75;
			_cellSize = 5;
			_delay = delay;
			this._initCommon();

			_window = SDL.SDL_CreateWindow("Conway's Game of Life: High Life", SDL.SDL_WINDOWPOS_CENTERED, 30, _gridWidth * (_cellSize + 1) - 1, _gridHeight * (_cellSize + 1) - 1 + _margin, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
			_renderer = SDL.SDL_CreateRenderer(_window, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

			_wrap = wrap;
			this._initDefaultHL(preset);

			string rules = "B36/S23";
			_rules = rules;

			_bornNums = new List<int>();
			_aliveNums = new List<int>();

			int stringIter = 0;
			while (true)
			{
				if (rules[stringIter] == 'B' || rules[stringIter] == 'b')
				{
					stringIter++;
					continue;
				}
				else if (rules[stringIter] == '/')
				{
					stringIter += 2;
					break;
				}
				else
				{
					_bornNums.Add(rules[stringIter] - '0');
				}

				stringIter++;
			}
			while (true)
			{
				if (stringIter == rules.Length) break;

				_aliveNums.Add(rules[stringIter] - '0');
				stringIter++;
			}
		}

		public GameOfLife(int width, int height, int cellSize, uint delay, string rules, bool wrap, bool[,] grid)
		{
			// Initialize SDL
			SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
			SDL_ttf.TTF_Init();

			// Initialize members
			_gridWidth = width;
			_gridHeight = height;
			_cellSize = cellSize;
			_delay = delay;

			this._initCommon();

			_startGrid = grid;

			int windowWidth = _gridWidth * (_cellSize + 1) - 1;
			if (windowWidth < _generationLabelPos.x + _generationLabelPos.w + 10)
			{
				windowWidth = _generationLabelPos.x + _generationLabelPos.w + 10;
			}

			_window = SDL.SDL_CreateWindow("Conway's Game of Life", SDL.SDL_WINDOWPOS_CENTERED_DISPLAY(0), 30, windowWidth, _gridHeight * (_cellSize + 1) - 1 + _margin, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
			_renderer = SDL.SDL_CreateRenderer(_window, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

			_wrap = wrap;

			_bornNums = new List<int>();
			_aliveNums = new List<int>();

			_rules = rules;

			int stringIter = 0;
			while (true)
			{
				if (rules[stringIter] == 'B' || rules[stringIter] == 'b')
				{
					stringIter++;
					continue;
				}
				else if (rules[stringIter] == '/')
				{
					stringIter += 2;
					break;
				}
				else
				{
					_bornNums.Add(rules[stringIter] - '0');
				}

				stringIter++;
			}
			while (true)
			{
				if (stringIter == rules.Length) break;

				_aliveNums.Add(rules[stringIter] - '0');
				stringIter++;
			}
		}

		private void _destroy()
		{
			SDL.SDL_DestroyWindow(_window);
			SDL.SDL_DestroyRenderer(_renderer);

			SDL.SDL_FreeSurface(_playPauseButton);
			SDL.SDL_FreeSurface(_stopButton);
			SDL.SDL_FreeSurface(_advanceButton);
			SDL.SDL_FreeSurface(_clearButton);
			SDL.SDL_FreeSurface(_quitButton);

			SDL_ttf.TTF_CloseFont(_textFont);

			SDL_ttf.TTF_Quit();
			SDL.SDL_Quit();
		}

		private void _initCommon()
		{
			_textFont = SDL_ttf.TTF_OpenFont("C:\\Windows\\Fonts\\tahoma.ttf", 24);

			_holding = false;

			_running = true;
			_settingUp = true;
			_paused = false;
			_suspended = false;
			_advance = false;

			_margin = 30;

			_startGrid = new bool[_gridWidth, _gridHeight];
			for (int i = 0; i < _gridWidth; i++)
			{
				for (int j = 0; j < _gridHeight; j++)
				{
					_startGrid[i, j] = false;
				}
			}

			_mouseClickPos = new Point();

			SDL.SDL_Color white;// = { 0xff, 0xff, 0xff, 0xff };
			white.r = 0xff;
			white.g = 0xff;
			white.b = 0xff;
			white.a = 0xff;
			_playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Start", white);
			_stopButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Stop", white);
			_advanceButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Advance", white);
			_clearButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Clear", white);
			_quitButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Quit", white);

			_generationLabelPos = new SDL.SDL_Rect();

			_generationLabelPos.x = 10;// 310;
			_generationLabelPos.y = 5;
			_generationLabelPos.w = 100;
			_generationLabelPos.h = 20;
		}

		private void _initDefaultGOL(GOL_PRESET preset)
		{
			if (preset == GOL_PRESET.GOL_GLIDERGUN_SYNTH)
			{
				_startGrid[0, 2] = true;
				_startGrid[1, 0] = true;
				_startGrid[1, 2] = true;
				_startGrid[2, 1] = true;
				_startGrid[2, 2] = true;

				_startGrid[15, 2] = true;
				_startGrid[15, 4] = true;
				_startGrid[16, 3] = true;
				_startGrid[16, 4] = true;
				_startGrid[17, 3] = true;

				_startGrid[29, 0] = true;
				_startGrid[29, 2] = true;
				_startGrid[30, 1] = true;
				_startGrid[30, 2] = true;
				_startGrid[31, 1] = true;

				_startGrid[37, 4] = true;
				_startGrid[38, 2] = true;
				_startGrid[38, 4] = true;
				_startGrid[39, 3] = true;
				_startGrid[39, 4] = true;

				_startGrid[14, 14] = true;
				_startGrid[15, 12] = true;
				_startGrid[15, 13] = true;
				_startGrid[16, 13] = true;
				_startGrid[16, 14] = true;

				_startGrid[28, 12] = true;
				_startGrid[29, 10] = true;
				_startGrid[29, 11] = true;
				_startGrid[30, 11] = true;
				_startGrid[30, 12] = true;

				_startGrid[19, 19] = true;
				_startGrid[19, 20] = true;
				_startGrid[20, 19] = true;
				_startGrid[20, 21] = true;
				_startGrid[21, 19] = true;

				_startGrid[24, 22] = true;
				_startGrid[25, 21] = true;
				_startGrid[25, 22] = true;
				_startGrid[26, 21] = true;
				_startGrid[26, 23] = true;

				_startGrid[32, 19] = true;
				_startGrid[32, 20] = true;
				_startGrid[32, 21] = true;
				_startGrid[33, 19] = true;
				_startGrid[34, 20] = true;

				_startGrid[38, 20] = true;
				_startGrid[39, 19] = true;
				_startGrid[39, 20] = true;
				_startGrid[40, 19] = true;
				_startGrid[40, 21] = true;

				_startGrid[50, 15] = true;
				_startGrid[50, 16] = true;
				_startGrid[51, 15] = true;
				_startGrid[51, 17] = true;
				_startGrid[52, 15] = true;

				_startGrid[40, 27] = true;
				_startGrid[40, 28] = true;
				_startGrid[41, 27] = true;
				_startGrid[41, 29] = true;
				_startGrid[42, 27] = true;

				_startGrid[51, 22] = true;
				_startGrid[51, 23] = true;
				_startGrid[51, 24] = true;
				_startGrid[52, 22] = true;
				_startGrid[53, 23] = true;
			}
			else if (preset == GOL_PRESET.GOL_X)
			{
				for (int i = 0; i < _gridWidth; i++)
				{
					for (int j = 0; j < _gridHeight; j++)
					{
						if (i == j || i == _gridHeight - j - 1 || _gridWidth - i - 1 == j)
							_startGrid[i, j] = true;
					}
				}
			}
			else if (preset == GOL_PRESET.GOL_CROSS)
			{
				for (int i = 0; i < _gridWidth; i++)
				{
					for (int j = 0; j < _gridHeight; j++)
					{
						if (i == _gridWidth / 2 || j == _gridHeight / 2)
							_startGrid[i, j] = true;
					}
				}
			}
			else if (preset == GOL_PRESET.GOL_HORIZONTAL)
			{
				for (int i = 0; i < _gridWidth; i++)
				{
					_startGrid[i, _gridHeight / 2] = true;
				}
			}
			else if (preset == GOL_PRESET.GOL_VERTICAL)
			{
				for (int i = 0; i < _gridHeight; i++)
				{
					_startGrid[_gridWidth / 2, i] = true;
				}
			}
			else if (preset == GOL_PRESET.GOL_VORTEX)
			{
				_startGrid[27, 11] = true;
				_startGrid[27, 13] = true;
				_startGrid[28, 12] = true;
				_startGrid[28, 13] = true;
				_startGrid[29, 12] = true;

				_startGrid[61, 27] = true;
				_startGrid[61, 28] = true;
				_startGrid[62, 28] = true;
				_startGrid[62, 29] = true;
				_startGrid[63, 27] = true;

				_startGrid[11, 47] = true;
				_startGrid[12, 45] = true;
				_startGrid[12, 46] = true;
				_startGrid[13, 46] = true;
				_startGrid[13, 47] = true;

				_startGrid[45, 62] = true;
				_startGrid[46, 61] = true;
				_startGrid[46, 62] = true;
				_startGrid[47, 61] = true;
				_startGrid[47, 63] = true;

				_startGrid[27, 30] = true;
				_startGrid[28, 31] = true;
				_startGrid[28, 32] = true;
				_startGrid[29, 30] = true;
				_startGrid[29, 31] = true;

				_startGrid[32, 26] = true;
				_startGrid[32, 27] = true;
				_startGrid[33, 27] = true;
				_startGrid[33, 28] = true;
				_startGrid[34, 26] = true;

				_startGrid[42, 28] = true;
				_startGrid[43, 28] = true;
				_startGrid[43, 29] = true;
				_startGrid[44, 27] = true;
				_startGrid[44, 29] = true;

				_startGrid[46, 33] = true;
				_startGrid[47, 32] = true;
				_startGrid[47, 33] = true;
				_startGrid[48, 32] = true;
				_startGrid[48, 34] = true;

				_startGrid[26, 40] = true;
				_startGrid[26, 42] = true;
				_startGrid[27, 41] = true;
				_startGrid[27, 42] = true;
				_startGrid[28, 41] = true;

				_startGrid[30, 45] = true;
				_startGrid[30, 47] = true;
				_startGrid[31, 45] = true;
				_startGrid[31, 46] = true;
				_startGrid[32, 46] = true;

				_startGrid[40, 48] = true;
				_startGrid[41, 46] = true;
				_startGrid[41, 47] = true;
				_startGrid[42, 47] = true;
				_startGrid[42, 48] = true;

				_startGrid[45, 43] = true;
				_startGrid[45, 44] = true;
				_startGrid[46, 42] = true;
				_startGrid[46, 43] = true;
				_startGrid[47, 44] = true;
			}
			else if (preset == GOL_PRESET.GOL_VORTEXFAIL)
			{
				_startGrid[26, 11] = true;
				_startGrid[26, 13] = true;
				_startGrid[27, 12] = true;
				_startGrid[27, 13] = true;
				_startGrid[28, 12] = true;

				_startGrid[60, 26] = true;
				_startGrid[60, 27] = true;
				_startGrid[61, 27] = true;
				_startGrid[61, 28] = true;
				_startGrid[62, 26] = true;

				_startGrid[11, 47] = true;
				_startGrid[12, 45] = true;
				_startGrid[12, 46] = true;
				_startGrid[13, 46] = true;
				_startGrid[13, 47] = true;

				_startGrid[45, 61] = true;
				_startGrid[46, 60] = true;
				_startGrid[46, 61] = true;
				_startGrid[47, 60] = true;
				_startGrid[47, 62] = true;

				_startGrid[27, 30] = true;
				_startGrid[28, 31] = true;
				_startGrid[28, 32] = true;
				_startGrid[29, 30] = true;
				_startGrid[29, 31] = true;

				_startGrid[32, 26] = true;
				_startGrid[32, 27] = true;
				_startGrid[33, 27] = true;
				_startGrid[33, 28] = true;
				_startGrid[34, 26] = true;

				_startGrid[41, 28] = true;
				_startGrid[42, 28] = true;
				_startGrid[42, 29] = true;
				_startGrid[43, 27] = true;
				_startGrid[43, 29] = true;

				_startGrid[45, 33] = true;
				_startGrid[46, 32] = true;
				_startGrid[46, 33] = true;
				_startGrid[47, 32] = true;
				_startGrid[47, 34] = true;

				_startGrid[26, 39] = true;
				_startGrid[26, 41] = true;
				_startGrid[27, 40] = true;
				_startGrid[27, 41] = true;
				_startGrid[28, 40] = true;

				_startGrid[30, 44] = true;
				_startGrid[30, 46] = true;
				_startGrid[31, 44] = true;
				_startGrid[31, 45] = true;
				_startGrid[32, 45] = true;

				_startGrid[39, 47] = true;
				_startGrid[40, 45] = true;
				_startGrid[40, 46] = true;
				_startGrid[41, 46] = true;
				_startGrid[41, 47] = true;

				_startGrid[44, 42] = true;
				_startGrid[44, 43] = true;
				_startGrid[45, 41] = true;
				_startGrid[45, 42] = true;
				_startGrid[46, 43] = true;
			}
		}

		private void _initDefaultHL(HL_PRESET preset)
		{
			if (preset == HL_PRESET.HL_REPLICATOR)
			{
				Point center = new Point(_gridWidth / 2, _gridHeight / 2);

				_startGrid[center.X - 2, center.Y] = true;
				_startGrid[center.X - 2, center.Y + 1] = true;
				_startGrid[center.X - 2, center.Y + 2] = true;
				_startGrid[center.X - 1, center.Y - 1] = true;
				_startGrid[center.X - 1, center.Y + 2] = true;
				_startGrid[center.X, center.Y - 2] = true;
				_startGrid[center.X, center.Y + 2] = true;
				_startGrid[center.X + 1, center.Y - 2] = true;
				_startGrid[center.X + 1, center.Y + 1] = true;
				_startGrid[center.X + 2, center.Y - 2] = true;
				_startGrid[center.X + 2, center.Y - 1] = true;
				_startGrid[center.X + 2, center.Y] = true;
			}
		}

		private void _pollEvent()
		{
			_clicked = false;
			while (SDL.SDL_PollEvent(out _event) > 0)
			{
				switch (_event.type)
				{
					case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
						if (_event.button.button == SDL.SDL_BUTTON_LEFT)
						{
							_holding = true;
							_clicked = true;
							_leftClick = true;
							_mouseClickPos.X = _event.button.x;
							_mouseClickPos.Y = _event.button.y;
						}
						else if (_event.button.button == SDL.SDL_BUTTON_RIGHT)
						{
							_holding = true;
							_clicked = true;
							_leftClick = false;
							_mouseClickPos.X = _event.button.x;
							_mouseClickPos.Y = _event.button.y;
						}
						break;

					case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:
						_holding = false;
						break;

					case SDL.SDL_EventType.SDL_MOUSEMOTION:
						if (!_holding) break;
						_mouseClickPos.X = _event.motion.x;
						_mouseClickPos.Y = _event.motion.y;
						break;
				}
			}
		}

		private void _initGrid()
		{
			_grid = new bool[_gridWidth, _gridHeight];
			for (int i = 0; i < _gridWidth; i++)
			{
				for (int j = 0; j < _gridHeight; j++)
				{
					_grid[i, j] = _startGrid[i, j];
				}
			}

			_generationCount = 0;
		}

		private void _drawGrid()
		{
			// Draw the grid
			SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
			SDL.SDL_RenderClear(_renderer);

			SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
			SDL.SDL_Rect rect = new SDL.SDL_Rect();
			rect.x = 0;
			rect.y = _margin;
			rect.w = _gridWidth * (_cellSize + 1) - 1;
			rect.h = _gridHeight * (_cellSize + 1) - 1;
			SDL.SDL_RenderFillRect(_renderer, ref rect);

			SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
			int i;
			for (i = 1; i < _gridWidth; i++)
			{
				SDL.SDL_RenderDrawLine(_renderer, i * (_cellSize + 1) - 1, _margin, i * (_cellSize + 1) - 1, _gridHeight * (_cellSize + 1) - 1 + _margin);
			}
			for (i = 1; i < _gridHeight; i++)
			{
				SDL.SDL_RenderDrawLine(_renderer, 0, i * (_cellSize + 1) - 1 + _margin, _gridWidth * (_cellSize + 1) - 1, i * (_cellSize + 1) - 1 + _margin);
			}

			SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
			for (i = 0; i < _gridWidth; i++)
			{
				for (int j = 0; j < _gridHeight; j++)
				{
					if (_settingUp && !_startGrid[i, j]) continue;
					else if (!_settingUp && !_grid[i, j]) continue;

					rect.x = i * _cellSize + i;
					rect.y = j * _cellSize + j + _margin;
					rect.w = _cellSize;
					rect.h = _cellSize;
					SDL.SDL_RenderFillRect(_renderer, ref rect);
				}
			}

			/*
			// Draw GUI elements
			SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);

			IntPtr tempPtr;

			unsafe
			{

				IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
				tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
				Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
				SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
				SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
				SDL.SDL_DestroyTexture(temp);
				Marshal.Release(tempPtr);

				temp = SDL.SDL_CreateTextureFromSurface(_renderer, _advanceButton);
				tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
				Marshal.StructureToPtr(_advanceButtonPos, tempPtr, false);
				SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
				SDL.SDL_RenderDrawRect(_renderer, ref _advanceButtonPos);
				SDL.SDL_DestroyTexture(temp);
				Marshal.Release(tempPtr);

				temp = SDL.SDL_CreateTextureFromSurface(_renderer, _clearButton);
				tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
				Marshal.StructureToPtr(_clearButtonPos, tempPtr, false);
				SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
				SDL.SDL_RenderDrawRect(_renderer, ref _clearButtonPos);
				SDL.SDL_DestroyTexture(temp);
				Marshal.Release(tempPtr);

				temp = SDL.SDL_CreateTextureFromSurface(_renderer, _quitButton);
				tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
				Marshal.StructureToPtr(_quitButtonPos, tempPtr, false);
				SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
				SDL.SDL_RenderDrawRect(_renderer, ref _quitButtonPos);
				SDL.SDL_DestroyTexture(temp);
				Marshal.Release(tempPtr);

			}*/

			SDL.SDL_RenderPresent(_renderer);
		}

		private void _setupGrid()
		{
			if (!_clicked && !_holding) return;

			if (_mouseClickPos.Y < _margin) return;
			if (_mouseClickPos.X > _gridWidth * (_cellSize + 1) - 1) return;

			_mouseClickPos.Y -= _margin;

			Point clickedCell = new Point(-1, -1);

			while (_mouseClickPos.X >= 0)
			{
				clickedCell.X++;
				_mouseClickPos.X -= (_cellSize + 1);
			}
			while (_mouseClickPos.Y >= 0)
			{
				clickedCell.Y++;
				_mouseClickPos.Y -= (_cellSize + 1);
			}

			_grid[clickedCell.X, clickedCell.Y] = _leftClick;
			if (!_paused) _startGrid[clickedCell.X, clickedCell.Y] = _leftClick;

			if (_leftClick)
			{
				SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
			}
			else
			{
				SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
			}

			SDL.SDL_Rect rect = new SDL.SDL_Rect();
			rect.x = clickedCell.X * _cellSize + clickedCell.X;
			rect.y = clickedCell.Y * _cellSize + clickedCell.Y + _margin;
			rect.w = _cellSize;
			rect.h = _cellSize;
			SDL.SDL_RenderFillRect(_renderer, ref rect);
			SDL.SDL_RenderPresent(_renderer);
		}

		private void _simulate()
		{
			_generationCount++;

			string s = "Generations: " + Convert.ToString(_generationCount);
			SDL.SDL_Color white = new SDL.SDL_Color();
			white.r = 0xff;
			white.g = 0xff;
			white.b = 0xff;
			white.a = 0xff;
			IntPtr generationLabel = SDL_ttf.TTF_RenderText_Solid(_textFont, s, white);
			IntPtr generationTex = SDL.SDL_CreateTextureFromSurface(_renderer, generationLabel);
			SDL.SDL_FreeSurface(generationLabel);

			SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
			SDL.SDL_RenderFillRect(_renderer, ref _generationLabelPos);

			unsafe
			{

				IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
				Marshal.StructureToPtr(_generationLabelPos, tempPtr, false);
				SDL.SDL_RenderCopy(_renderer, generationTex, IntPtr.Zero, tempPtr);
				SDL.SDL_DestroyTexture(generationTex);
				Marshal.Release(tempPtr);

			}

			bool[,] nextGen = new bool[_gridWidth, _gridHeight];
			int l, j;
			for (l = 0; l < _gridWidth; l++)
			{
				for (j = 0; j < _gridHeight; j++)
				{
					nextGen[l, j] = _grid[l, j];
				}
			}

			List<Point> neighbors = new List<Point>();

			//Parallel.For(0, _gridWidth, i =>

			for (int i = 0; i < _gridWidth; i++)
			{
				for (j = 0; j < _gridHeight; j++)
				{
					// Determine which neighbors to consider
					//List<Point> neighbors = new List<Point>();
					if (_wrap) _getNeighborsWrapped(i, j, ref neighbors);
					else _getNeighbors(i, j, ref neighbors);

					// Count how many live neighbors for the current cell
					int liveCount = 0;
					int k;
					for (k = 0; k < neighbors.Count; k++)
					{
						if (_grid[neighbors[k].X, neighbors[k].Y]) liveCount++;
					}

					neighbors.Clear();

					// Check if a cell should die according to the rules
					bool flag = false;
					for (k = 0; k < _aliveNums.Count; k++)
					{
						if (liveCount == _aliveNums[k]) break;
					}
					if (k == _aliveNums.Count) flag = true;

					if (_grid[i, j] && flag)
					{
						SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
						nextGen[i, j] = false;

						SDL.SDL_Rect rect = new SDL.SDL_Rect();
						rect.x = i * _cellSize + i;
						rect.y = j * _cellSize + j + _margin;
						rect.w = _cellSize;
						rect.h = _cellSize;
						SDL.SDL_RenderFillRect(_renderer, ref rect);
					}

					// Check if a cell should be born according to the rules
					flag = false;
					for (k = 0; k < _bornNums.Count; k++)
					{
						if (liveCount == _bornNums[k]) flag = true;
					}

					if (!_grid[i, j] && flag)
					{
						SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
						nextGen[i, j] = true;

						SDL.SDL_Rect rect = new SDL.SDL_Rect();
						rect.x = i * _cellSize + i;
						rect.y = j * _cellSize + j + _margin;
						rect.w = _cellSize;
						rect.h = _cellSize;
						SDL.SDL_RenderFillRect(_renderer, ref rect);
					}
				}
			}//); // Parallel.For

			for (l = 0; l < _gridWidth; l++)
			{
				for (j = 0; j < _gridHeight; j++)
				{
					_grid[l, j] = nextGen[l, j];
				}
			}

			SDL.SDL_RenderPresent(_renderer);
		}

		private void _getNeighbors(int x, int y, ref List<Point> neighbors)
		{
			Point temp = new Point(x, y - 1);

			// Get top neighbor
			if (temp.Y >= 0) neighbors.Add(temp);

			// Get top-right neighbor
			temp.X = x + 1;
			temp.Y = y - 1;
			if (temp.X < _gridWidth && temp.Y >= 0) neighbors.Add(temp);

			// Get right neighbor
			temp.X = x + 1;
			temp.Y = y;
			if (temp.X < _gridWidth) neighbors.Add(temp);

			// Get bottom-right neighbor
			temp.X = x + 1;
			temp.Y = y + 1;
			if (temp.X < _gridWidth && temp.Y < _gridHeight) neighbors.Add(temp);

			// Get bottom neighbor
			temp.X = x;
			temp.Y = y + 1;
			if (temp.Y < _gridHeight) neighbors.Add(temp);

			// Get bottom-left neighbor
			temp.X = x - 1;
			temp.Y = y + 1;
			if (temp.X >= 0 && temp.Y < _gridHeight) neighbors.Add(temp);

			// Get left neighbor
			temp.X = x - 1;
			temp.Y = y;
			if (temp.X >= 0) neighbors.Add(temp);

			// Get top-left neighbor
			temp.X = x - 1;
			temp.Y = y - 1;
			if (temp.X >= 0 && temp.Y >= 0) neighbors.Add(temp);
		}

		private void _getNeighborsWrapped(int x, int y, ref List<Point> neighbors)
		{
			Point temp = new Point(x, y - 1);

			// Get top neighbor
			if (temp.Y < 0) temp.Y = _gridHeight - 1;
			neighbors.Add(temp);

			// Get top-right neighbor
			temp.X = x + 1;
			temp.Y = y - 1;
			if (temp.X == _gridWidth) temp.X = 0;
			if (temp.Y < 0) temp.Y = _gridHeight - 1;
			neighbors.Add(temp);

			// Get right neighbor
			temp.X = x + 1;
			temp.Y = y;
			if (temp.X == _gridWidth) temp.X = 0;
			neighbors.Add(temp);

			// Get bottom-right neighbor
			temp.X = x + 1;
			temp.Y = y + 1;
			if (temp.X == _gridWidth) temp.X = 0;
			if (temp.Y == _gridHeight) temp.Y = 0;
			neighbors.Add(temp);

			// Get bottom neighbor
			temp.X = x;
			temp.Y = y + 1;
			if (temp.Y == _gridHeight) temp.Y = 0;
			neighbors.Add(temp);

			// Get bottom-left neighbor
			temp.X = x - 1;
			temp.Y = y + 1;
			if (temp.X < 0) temp.X = _gridWidth - 1;
			if (temp.Y == _gridHeight) temp.Y = 0;
			neighbors.Add(temp);

			// Get left neighbor
			temp.X = x - 1;
			temp.Y = y;
			if (temp.X < 0) temp.X = _gridWidth - 1;
			neighbors.Add(temp);

			// Get top-left neighbor
			temp.X = x - 1;
			temp.Y = y - 1;
			if (temp.X < 0) temp.X = _gridWidth - 1;
			if (temp.Y < 0) temp.Y = _gridHeight - 1;
			neighbors.Add(temp);
		}

		private void _saveToFile()
		{
			string data = "";
			data += _rules + "\r\n";
			data += _gridWidth + "\r\n";
			data += _gridHeight + "\r\n";
			data += _cellSize + "\r\n";

			for (int x = 0; x < _gridWidth; x++)
			{
				for (int y = 0; y < _gridHeight; y++)
				{
					if (_startGrid[x, y])
					{
						data += Convert.ToString(x) + " " + Convert.ToString(y) + "\r\n";
					}
				}
			}

			StreamWriter file = Global.fStreams.Take();
			file.Write(data);

			Global.saved.Add(true);
		}

		private void _insertStruct()
		{
			// Grab boolean data for the structure to add
			bool[,] structure = Global.structures.Take();

			// If the structure is too big, do nothing
			if (structure.GetLength(0) > _gridWidth || structure.GetLength(1) > _gridHeight) return;

			SDL.SDL_Rect rect = new SDL.SDL_Rect();
			rect.w = _cellSize;
			rect.h = _cellSize;

			// Loop until the user is happy with the structure
			bool finished = false;
			bool first = true;
			bool clicked = false;
			Point prevOriginCell = new Point(-1, -1);
			while (!finished)
			{
				// Stores the mouse coordinates
				Point mouse = new Point(-1, -1);

				while(SDL.SDL_PollEvent(out _event) > 0)
				{
					switch (_event.type)
					{
						case SDL.SDL_EventType.SDL_MOUSEMOTION:
							mouse.X = _event.motion.x;
							mouse.Y = _event.motion.y;
							break;
						case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
							clicked = true;
							mouse.X = _event.button.x;
							mouse.Y = _event.button.y;
							break;
					}
				}

				// Do nothing if the mouse is outside the grid area
				if (mouse.Y < _margin) continue;
				if (mouse.X > _gridWidth * (_cellSize + 1) - 1) continue;

				// Calculate which cell the mouse is pointing at
				mouse.Y -= _margin;
				Point originCell = new Point(-1, -1);
				while (mouse.X >= 0)
				{
					originCell.X++;
					mouse.X -= (_cellSize + 1);
				}
				while (mouse.Y >= 0)
				{
					originCell.Y++;
					mouse.Y -= (_cellSize + 1);
				}

				// Don't allow the structure outside the bounds of the grid
				if (originCell.X + structure.GetLength(0) > _gridWidth) originCell.X -= structure.GetLength(0) + originCell.X - _gridWidth;
				if (originCell.Y + structure.GetLength(1) > _gridHeight) originCell.Y -= structure.GetLength(1) + originCell.Y - _gridHeight;

				// Draw the structure at that point
				for (int x = 0; x < structure.GetLength(0); x++)
				{
					for (int y = 0; y < structure.GetLength(1); y++)
					{
						if (!first)
						{
							// Erase the previous location from the drawn grid
							SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
							rect.x = (x + prevOriginCell.X) * _cellSize + x + prevOriginCell.X;
							rect.y = (y + prevOriginCell.Y) * _cellSize + y + prevOriginCell.Y + _margin;
							SDL.SDL_RenderFillRect(_renderer, ref rect);

							// Draw any parts of the grid that should be there, that we might have erased
							SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
							if (_grid[x + prevOriginCell.X, y + prevOriginCell.Y])
							{
								rect.x = (x + prevOriginCell.X) * _cellSize + x + prevOriginCell.X;
								rect.y = (y + prevOriginCell.Y) * _cellSize + y + prevOriginCell.Y + _margin;
								SDL.SDL_RenderFillRect(_renderer, ref rect);
							}
						}

						// Draw the structure
						if (clicked) SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0xff, 0xff);
						else SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0x00, 0xff);
						if (structure[x, y])
						{
							rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
							rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
							SDL.SDL_RenderFillRect(_renderer, ref rect);
						}
					}
				}

				SDL.SDL_RenderPresent(_renderer);
				first = false;
				prevOriginCell = originCell;
				if (!clicked) continue;

				while (Global.buttons.Count > 0)
				{
					System.Windows.Forms.Button button = Global.buttons.Take();
					button.Invoke((System.Windows.Forms.MethodInvoker)delegate
					{
						button.Enabled = true;
					});
				}

				while (!finished && clicked)
				{
					// Clear the SDL event queue
					while (SDL.SDL_PollEvent(out _event) > 0) ;
					while (Global.messages.Count > 0)
					{
						GOL_Message message = Global.messages.Take();

						#region Finished
						// If the user is happy with the structure, finalize everything
						if (message == GOL_Message.Quit)
						{
							finished = true;
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									if (_settingUp) _startGrid[x + originCell.X, y + originCell.Y] = structure[x, y];
									_grid[x + originCell.X, y + originCell.Y] = structure[x, y];

									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}
							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion

						#region Move
						// If the user wants to move the structure manually again
						else if (message == GOL_Message.Move)
						{
							clicked = false;
							first = true;
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Erase the structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
									// Redraw any necessary cells
									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (_grid[x + originCell.X, y + originCell.Y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}
							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion

						#region Rotate CCW
						// If the user wants to rotate the structure CCW
						else if(message == GOL_Message.RotateLeft)
						{
							bool[,] old = structure;
							structure = new bool[old.GetLength(1), old.GetLength(0)];
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Assign the values to the new structure
									structure[x, y] = old[structure.GetLength(1) - 1 - y, x];

									// Erase the old structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
									if (old[y, x])
									{
										rect.y = (x + originCell.Y) * _cellSize + x + originCell.Y + _margin;
										rect.x = (y + originCell.X) * _cellSize + y + originCell.X;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
									// Redraw any necessary cells
									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (_grid[y + originCell.X, x + originCell.Y])
									{
										rect.y = (x + originCell.Y) * _cellSize + x + originCell.Y + _margin;
										rect.x = (y + originCell.X) * _cellSize + y + originCell.X;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Draw the new structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0xff, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion

						#region Rotate CW
						// If the user wants to rotate the structure CW
						else if(message == GOL_Message.RotateRight)
						{
							bool[,] old = structure;
							structure = new bool[old.GetLength(1), old.GetLength(0)];
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Assign the values to the new structure
									structure[x, y] = old[y, structure.GetLength(0) - 1 - x];

									// Erase the old structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
									if (old[y, x])
									{
										rect.y = (x + originCell.Y) * _cellSize + x + originCell.Y + _margin;
										rect.x = (y + originCell.X) * _cellSize + y + originCell.X;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
									// Redraw any necessary cells
									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (_grid[y + originCell.X, x + originCell.Y])
									{
										rect.y = (x + originCell.Y) * _cellSize + x + originCell.Y + _margin;
										rect.x = (y + originCell.X) * _cellSize + y + originCell.X;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Draw the new structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0xff, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion

						#region Flip Horizontal
						// If the user wants to flip the structure horizontally
						else if (message == GOL_Message.FlipHorizontal)
						{
							bool[,] old = structure;
							structure = new bool[structure.GetLength(0), structure.GetLength(1)];
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Assign the values to the new structure
									structure[x, y] = old[structure.GetLength(0) - 1 - x, y];

									// Erase the old structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
									if (old[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
									// Redraw any necessary cells
									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (_grid[x + originCell.X, y + originCell.Y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Draw the new structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0xff, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion

						#region Flip Vertical
						// If the user wants to flip the structure vertically
						else if (message == GOL_Message.FlipVertical)
						{
							bool[,] old = structure;
							structure = new bool[structure.GetLength(0), structure.GetLength(1)];
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Assign the values to the new structure
									structure[x, y] = old[x, structure.GetLength(1) - 1 - y];

									// Erase the old structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
									if (old[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
									// Redraw any necessary cells
									SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0x00, 0xff, 0xff);
									if (_grid[x + originCell.X, y + originCell.Y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}
							for (int x = 0; x < structure.GetLength(0); x++)
							{
								for (int y = 0; y < structure.GetLength(1); y++)
								{
									// Draw the new structure
									SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0xff, 0xff, 0xff);
									if (structure[x, y])
									{
										rect.x = (x + originCell.X) * _cellSize + x + originCell.X;
										rect.y = (y + originCell.Y) * _cellSize + y + originCell.Y + _margin;
										SDL.SDL_RenderFillRect(_renderer, ref rect);
									}
								}
							}

							SDL.SDL_RenderPresent(_renderer);
						}
						#endregion
					}
				}// while(!finished && clicked)
			}
		}

		private void _checkToolBoxMessages()
		{
			// Check for messages from the toolbox
			while (Global.messages.Count > 0)
			{
				GOL_Message message = Global.messages.Take();

				switch (message)
				{
					case GOL_Message.Start:
						_settingUp = false;
						break;
					case GOL_Message.Pause:
						_paused = true;
						break;
					case GOL_Message.Suspend:
						_suspended = true;
						break;
					case GOL_Message.Resume:
						_paused = false;
						_suspended = false;
						break;
					case GOL_Message.Stop:
						_settingUp = true;
						_paused = false;
						break;
					case GOL_Message.Advance:
						if (_settingUp)
						{
							_settingUp = false;
							_paused = true;
						}
						_advance = true;
						break;
					case GOL_Message.Clear:
						SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
						SDL.SDL_Rect rect = new SDL.SDL_Rect();

						for (int i = 0; i < _gridWidth; i++)
						{
							for (int j = 0; j < _gridHeight; j++)
							{
								if (_startGrid[i, j])
								{
									_grid[i, j] = false;
									_startGrid[i, j] = false;
									rect.x = i * (_cellSize + 1);
									rect.y = j * (_cellSize + 1) + _margin;
									rect.w = _cellSize;
									rect.h = _cellSize;
									SDL.SDL_RenderFillRect(_renderer, ref rect);
								}
							}
						}
						SDL.SDL_RenderPresent(_renderer);
						break;
					case GOL_Message.Quit:
						_running = false;
						break;
					case GOL_Message.Save:
						_saveToFile();
						break;
					case GOL_Message.Insert:
						_insertStruct();
						break;
					case GOL_Message.ChangeCellSize:
						_cellSize = Global.intData.Take();
						SDL.SDL_DestroyWindow(_window);
						SDL.SDL_DestroyRenderer(_renderer);
						int windowWidth = _gridWidth * (_cellSize + 1) - 1;
						if (windowWidth < _generationLabelPos.x + _generationLabelPos.w + 10)
						{
							windowWidth = _generationLabelPos.x + _generationLabelPos.w + 10;
						}
						_window = SDL.SDL_CreateWindow("Conway's Game of Life", SDL.SDL_WINDOWPOS_CENTERED_DISPLAY(0), 30, windowWidth, _gridHeight * (_cellSize + 1) - 1 + _margin, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
						_renderer = SDL.SDL_CreateRenderer(_window, -1, (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
						_drawGrid();
						break;
					case GOL_Message.ChangeDelay:
						_delay = Convert.ToUInt32(Global.intData.Take());
						break;
					case GOL_Message.ChangeWrap:
						_wrap = Global.intData.Take() == 1 ? true : false;
						break;
				}//switch
				_clicked = false;
			}
		}

		public void start()
		{
			while (true)
			{
				_initGrid();
				_drawGrid();

				_stopped = false;

				while (true)
				{
					_pollEvent();

					if (!_running) break;

					//_checkGUI();
					_checkToolBoxMessages();
					if (_suspended) continue;
					if (_settingUp)
					{
						if (_stopped) break;
						_setupGrid();
					}
					else
					{
						if (_paused)
						{
							_setupGrid();
							if (!_advance) continue;
						}

						_stopped = true;
						_simulate();

						if (!_advance) SDL.SDL_Delay(_delay);
						_advance = false;
					}
				}

				if (!_running) break;
			}

			this._destroy();
		}
		
		//private void _checkGUI()
		//{
		//    if (!_clicked) return;

		//    SDL.SDL_Color white = new SDL.SDL_Color();
		//    white.r = 0xff;
		//    white.g = 0xff;
		//    white.b = 0xff;
		//    white.a = 0xff;

		//    // Check if Play/Paused was clicked
		//    if (_mouseClickPos.X >= _playButtonPos.x && _mouseClickPos.X < (_playButtonPos.w + _playButtonPos.x)
		//        && _mouseClickPos.Y >= _playButtonPos.y && _mouseClickPos.Y < (_playButtonPos.h + _playButtonPos.y))
		//    {
		//        if (_settingUp && !_paused)
		//        {
		//            _settingUp = false;

		//            unsafe
		//            {

		//                SDL.SDL_FreeSurface(_playPauseButton);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
		//                SDL.SDL_RenderFillRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_RenderFillRect(_renderer, ref _advanceButtonPos);
		//                SDL.SDL_RenderFillRect(_renderer, ref _clearButtonPos);
		//                _playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Pause", white);
		//                IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
		//                IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//                temp = SDL.SDL_CreateTextureFromSurface(_renderer, _stopButton);
		//                tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_stopButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//                SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);
		//                SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_RenderDrawRect(_renderer, ref _stopButtonPos);

		//            }
		//        }
		//        else if (!_settingUp && !_paused)
		//        {
		//            _paused = true;

		//            unsafe
		//            {

		//                SDL.SDL_FreeSurface(_playPauseButton);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
		//                SDL.SDL_RenderFillRect(_renderer, ref _playButtonPos);
		//                _playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Resume", white);
		//                IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
		//                IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);
		//                SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//                temp = SDL.SDL_CreateTextureFromSurface(_renderer, _advanceButton);
		//                tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_advanceButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_RenderDrawRect(_renderer, ref _advanceButtonPos);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//            }
		//        }
		//        else
		//        {
		//            _paused = false;

		//            unsafe
		//            {

		//                SDL.SDL_FreeSurface(_playPauseButton);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
		//                SDL.SDL_RenderFillRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_RenderFillRect(_renderer, ref _advanceButtonPos);
		//                _playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Pause", white);
		//                IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
		//                IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);
		//                SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//            }
		//        }
		//    }

		//    // Check if Stop was clicked
		//    else if (_mouseClickPos.X >= _stopButtonPos.x && _mouseClickPos.X < (_stopButtonPos.w + _stopButtonPos.x)
		//        && _mouseClickPos.Y >= _stopButtonPos.y && _mouseClickPos.Y < (_stopButtonPos.h + _stopButtonPos.y))
		//    {
		//        if (_settingUp) return;
		//        _settingUp = true;
		//        _paused = false;

		//        unsafe
		//        {

		//            SDL.SDL_FreeSurface(_playPauseButton);
		//            SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
		//            SDL.SDL_RenderFillRect(_renderer, ref _playButtonPos);
		//            SDL.SDL_RenderFillRect(_renderer, ref _generationLabelPos);
		//            _playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Start", white);
		//            IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
		//            IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//            Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
		//            SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//            SDL.SDL_DestroyTexture(temp);
		//            Marshal.Release(tempPtr);

		//            temp = SDL.SDL_CreateTextureFromSurface(_renderer, _clearButton);
		//            tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//            Marshal.StructureToPtr(_clearButtonPos, tempPtr, false);
		//            SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//            SDL.SDL_DestroyTexture(temp);
		//            Marshal.Release(tempPtr);

		//        }

		//        SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);
		//        SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
		//        SDL.SDL_RenderDrawRect(_renderer, ref _clearButtonPos);
		//    }

		//    // Check if Advance was clicked
		//    else if (_mouseClickPos.X >= _advanceButtonPos.x && _mouseClickPos.X < (_advanceButtonPos.w + _advanceButtonPos.x)
		//        && _mouseClickPos.Y >= _advanceButtonPos.y && _mouseClickPos.Y < (_advanceButtonPos.h + _advanceButtonPos.y))
		//    {
		//        if (_settingUp)
		//        {
		//            _settingUp = false;
		//            _paused = true;

		//            unsafe
		//            {

		//                SDL.SDL_FreeSurface(_playPauseButton);
		//                SDL.SDL_SetRenderDrawColor(_renderer, 0x00, 0x00, 0x00, 0xff);
		//                SDL.SDL_RenderFillRect(_renderer, ref _playButtonPos);
		//                SDL.SDL_RenderFillRect(_renderer, ref _clearButtonPos);
		//                _playPauseButton = SDL_ttf.TTF_RenderText_Solid(_textFont, "Resume", white);
		//                IntPtr temp = SDL.SDL_CreateTextureFromSurface(_renderer, _playPauseButton);
		//                IntPtr tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_playButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//                temp = SDL.SDL_CreateTextureFromSurface(_renderer, _stopButton);
		//                tempPtr = Marshal.AllocHGlobal(sizeof(SDL.SDL_Rect));
		//                Marshal.StructureToPtr(_stopButtonPos, tempPtr, false);
		//                SDL.SDL_RenderCopy(_renderer, temp, IntPtr.Zero, tempPtr);
		//                SDL.SDL_DestroyTexture(temp);
		//                Marshal.Release(tempPtr);

		//            }

		//            SDL.SDL_SetRenderDrawColor(_renderer, 0xff, 0xff, 0xff, 0xff);
		//            SDL.SDL_RenderDrawRect(_renderer, ref _playButtonPos);
		//            SDL.SDL_RenderDrawRect(_renderer, ref _stopButtonPos);
		//        }
		//        if (!_paused) return;
		//        _advance = true;
		//    }

		//    // Check if Clear was clicked
		//    else if (_mouseClickPos.X >= _clearButtonPos.x && _mouseClickPos.X < (_clearButtonPos.w + _clearButtonPos.x)
		//        && _mouseClickPos.Y >= _clearButtonPos.y && _mouseClickPos.Y < (_clearButtonPos.h + _clearButtonPos.y))
		//    {
		//        if (!_settingUp) return;

		//        SDL.SDL_SetRenderDrawColor(_renderer, 0x30, 0x30, 0x40, 0xff);
		//        SDL.SDL_Rect rect = new SDL.SDL_Rect();

		//        for (int i = 0; i < _gridWidth; i++)
		//        {
		//            for (int j = 0; j < _gridHeight; j++)
		//            {
		//                if (_startGrid[i, j])
		//                {
		//                    _grid[i, j] = false;
		//                    _startGrid[i, j] = false;
		//                    rect.x = i * (_cellSize + 1);
		//                    rect.y = j * (_cellSize + 1) + _margin;
		//                    rect.w = _cellSize;
		//                    rect.h = _cellSize;
		//                    SDL.SDL_RenderFillRect(_renderer, ref rect);
		//                }
		//            }
		//        }
		//    }

		//    // Check if Quit was clicked
		//    else if (_mouseClickPos.X >= _quitButtonPos.x && _mouseClickPos.X < (_quitButtonPos.w + _quitButtonPos.x)
		//        && _mouseClickPos.Y >= _quitButtonPos.y && _mouseClickPos.Y < (_quitButtonPos.h + _quitButtonPos.y))
		//    {
		//        _running = false;
		//    }

		//    SDL.SDL_RenderPresent(_renderer);
		//}
    }
}