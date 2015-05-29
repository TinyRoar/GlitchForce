using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngineInternal;

public class GameEvents {

	private static GameEvents instance = null;
    public static GameEvents Instance
    {
        get
        {
            if(instance == null)
                instance = new GameEvents();
            return instance;
        }
    }

    /* Key Events */
    public delegate void InputHandler();
    public event InputHandler OnKey;
    public event InputHandler OnKeyDown;
    public event InputHandler OnLeftMouseDown;
    public event InputHandler OnRightMouseDown;

    //public delegate void GameStateChange(Config.GameState oldState, Config.GameState newState);
    //public event GameStateChange OnGameStateChange;

    public delegate void KeyUpHandler(KeyCode key);
    public event KeyUpHandler OnKeyUp;

    private List<KeyCode> keyList = new List<KeyCode>();
    private KeyCode[] specialKeys;
    private bool useSpecialKeys = true;

    public GameEvents()
    {
        instance = this;
        
        //GameMaster.Updater.OnUpdate += DoUpdate;

        specialKeys = new KeyCode[] {
                        KeyCode.UpArrow,
                        KeyCode.DownArrow,
                        KeyCode.LeftArrow,
                        KeyCode.RightArrow,
                        KeyCode.LeftControl,
                        KeyCode.LeftShift,
                        KeyCode.LeftAlt,
                        KeyCode.Escape
                    };
    }

	void DoUpdate()
    {

        // Check if new Key was pressed, Special Keys are not possible with these check
        if(useSpecialKeys == true)
        {
            string str = Input.inputString;
            if (str != "")
            {
                str = str.ToUpper();
                foreach (char c in str)
                {
                    KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString());
                    if (!keyList.Contains(key))
                    {
                        keyList.Add(key);
                    }
                }
            }
        }

        // Check Key still pressed
        if(Input.anyKey)
        {
            if (OnKey != null)
            {
                OnKey();
            }
        }

        // Check Key down
        if (Input.anyKeyDown)
        {
            if (OnKeyDown != null)
            {
                OnKeyDown();
            }
        }

        // Check Key Up
        for (int i = keyList.Count-1; i >= 0; i--)
        {
            KeyCode key = keyList[i];
            if (!Input.GetKey(key))
            {
                if (OnKeyUp != null)
                {
                    OnKeyUp(key);
                }
                keyList.Remove(key);
            }
        }

        // Check Arrow Key and Special Key Up
        if (useSpecialKeys == true)
        {
            foreach (var key in specialKeys)
            {
                if (Input.GetKeyUp(key))
                {
                    OnKeyUp(key);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(OnLeftMouseDown != null)
            {
                OnLeftMouseDown();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (OnRightMouseDown != null)
            {
                OnRightMouseDown();
            }
        }

	}

    /*public void FireChangeState()
    {
         if (OnGameStateChange != null)
         {
             OnGameStateChange(Config.Instance.lastGameState, Config.Instance.gameState);
         }
    }*/

    void OnDestroy()
    {
        Updater.Instance.OnUpdate -= DoUpdate;
    }



}
