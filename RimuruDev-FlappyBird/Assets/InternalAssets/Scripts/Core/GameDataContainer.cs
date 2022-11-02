using RimuruDev.Helpers;
using RimuruDev.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev.Core
{
    public sealed class GameDataContainer : MonoBehaviour
    {
        public static GameDataContainer eventontainer = null;

        [Header("Bird")]
        public GameObject birdPrefab;
        public float flyUpForce;
        public Rigidbody2D birdRigidbody;

        [Header("UI")]
        public int score;
        public int bestScore;
        public Text scoreText;

        [Header("Init")]
        public Vector2 birdSpawnPosition;

        [Header("Pipe")]
        public GameObject pipePrefab;
        public float pipeMotionSpeed;


        [Header("Pipe Generation")]
        public float pipeSpawnCooldown;
        public float pipeRandomPosition;
        public Vector2 pipeRandomRangeXY;
        public float pipeDestroyTimer;
        public bool isPipeSpawn;
        public float pipeSpawnPosX;

        [Header("Freez time")]
        public float timeScale;

        [Header("Failure")]
        public Text scoreTextFailurepanel;
        public Text bestScoreFailurepanel;
        public GameObject failurePanel;

        [Header("Runtime")]
        public GameObject birdClone;
        public Rigidbody2D birdRigidbody2DClone;
        public BirdCharacterController birdCharacterController;
        public PipeGeneratorController pipeGeneratorController;

        [Header("ECS")]

        public float timePopupSpawn;
        public float autoSaveTimer;
        public float autoSaveBestScoreTimer;

        private void Awake()
        {
            eventontainer = this;

            birdCharacterController = IsNullFind<BirdCharacterController>.Find(ref birdCharacterController, this);
            pipeGeneratorController = IsNullFind<PipeGeneratorController>.Find(ref pipeGeneratorController, this);
        }

        public void RestartLevel()=> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
