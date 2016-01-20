﻿using UnityEngine;
using System.Collections;
using Relax.Objects.Characters; 
using Relax.Interface; 

namespace Relax.Game {
    public class GameHandler : MonoBehaviour {
        private Robot _playerCharacter;
        public Robot playerCharacter {
            get {
                return _playerCharacter; 
            }
        }

        [System.Serializable]
        public struct GameObjective {
            public int day; 
            public Objective[] objective; 
        }
        public GameObjective[] gameObjectives; 
        private MainGameUIController mainUI;

        [System.Serializable]
        public struct IndicatorSprite {
            public string type; 
            public Sprite sprite; 
            public IndicatorSprite(string t, Sprite s) {
                type = t; sprite = s; 
            }
        }
        public IndicatorSprite[] indicatorSprites;

        private void Start() {
            if (FindObjectOfType<Robot>()) {
                _playerCharacter = FindObjectOfType<Robot>(); 
            } else {
                throw new MissingComponentException("No player character in scene!");
            }

            if (FindObjectOfType<MainGameUIController>()) {
                mainUI = FindObjectOfType<MainGameUIController>();
            } else {
                throw new MissingComponentException("No Main UI in scene"); 
            }

            Objective[] test = new Objective[3]{
                new Objective(false, "Test1"),
                new Objective(false, "Test2 with spacing ... ... .. .. . . . . . . . ."),
                new Objective(true, "Test 3 marked as complete\n with new line")
            };
            mainUI.UpdateObjectivesList(test); 
        }//Start

        private void Update() {
            if (Input.GetKeyDown(KeyCode.A)) {
                Objective[] test = new Objective[2]{
                new Objective(false, "I was switched. Testadadadadada1"),
                new Objective(false, "Test2 with spacing ... ... .. .. . . . . . . . .")
            };
                mainUI.UpdateObjectivesList(test); 
            }
        }//Update

        public void Pause() {
            if (Time.timeScale == 0) {
                Time.timeScale = 1;
            } else {
                Time.timeScale = 0; 
            }
        }//Pause

        public Sprite GetIndicatorSprite(string type ) {
            Sprite indicator = null; 
            for (int i = 0; i < indicatorSprites.Length; ++i) {
                if (type == indicatorSprites[i].type) {
                    indicator = indicatorSprites[i].sprite; 
                    i = indicatorSprites.Length; 
                }
            }
            if (indicator == null) {
                throw new UnityException("There was no indicator sprite with type " + type + " and null was returned. Please check the project."); 
            }
            return indicator; 
        }//GetIndicatorSprite
    }//GameHandler
}
