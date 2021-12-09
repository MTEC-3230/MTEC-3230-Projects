using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BarManager : MonoBehaviour
    {
        private static BarManager _instance;

        public static BarManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    //Must have barmanager in the scene
                    _instance = GameObject.FindObjectOfType<BarManager>();
                }

                return _instance;
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
    public string ID = "Recipe Manager";
    
    // Start is called before the first frame update
    //private static Drink currentTargetDrink;
    //private List<Drink> currentTargetRecipe = currentTargetDrink.components;

    /*                                                                  
        private Drink recipeOJ = new OrangeJuice();                               
        private Drink recipeVodka = new OrangeJuice();                            
        private Drink recipeOJ = new OrangeJuice();                               
        private Drink recipeOJ = new OrangeJuice();                               
        private Drink recipeOJ = new OrangeJuice();                               
        private Drink recipeOJ = new OrangeJuice();                               
                                                                            
        public static readonly Drink[,] MasterRecipeList =                        
        {                                                                         
        {null,              new OrangeJuice(), new Vodka(),new RedBull()},    
        {new OrangeJuice(), new OrangeJuice(), new Screwdriver(),   "None"  },
        {"Vodka",        "Screwdriver",  "Vodka",         "Redbull Vodka"},   
        {"Redbull",      "None",         "Redbull Vodka", "Redbull"}          
        };       */

    public Dictionary<string, Drink> MasterRecipeList = new Dictionary<string, Drink>();

    public void Start()
    {
        MasterRecipeList.Add("Screwdriver", gameObject.AddComponent<Screwdriver>());
        MasterRecipeList.Add("Redbull Vodka", gameObject.AddComponent<RedBullVodka>());
        MasterRecipeList.Add("Carribean Punch", gameObject.AddComponent<CarribeanPunch>());
        MasterRecipeList.Add("Monkey Gland", gameObject.AddComponent<MonkeyGland>());
        MasterRecipeList.Add("Tequila Sunrise", gameObject.AddComponent<TequilaSunrise>());
        MasterRecipeList.Add("Blue Hawaiian", gameObject.AddComponent<BlueHawaiian>());
        MasterRecipeList.Add("Vodka Cranberry", gameObject.AddComponent<VodkaCranberry>());

        GlassEvents.OnPour += aPour;

    }

    public void aPour(GameObject a, GameObject b)
    {
        Glass pourFrom = a.GetComponent<Glass>();
        Glass pourInto = b.GetComponent<Glass>();

        if (pourFrom == null || pourInto == null)
        {
            Debug.Log("Something went wrong");
            return;
        }

        if (pourFrom.currentDrinks.Count <= 0)
        {
            return;
        }

        bool doNotAdd = false;
        for (int i = 0; i < pourInto.currentDrinks.Count; i++)
        {
            if (pourInto.currentDrinks[i].ID.Equals(pourFrom.currentDrinks[0].ID))
            {
                doNotAdd = true;
            }
        }
        if (!doNotAdd)
        {
            foreach (Drink d in pourFrom.currentDrinks)
            {
                pourInto.AddDrink(d);
                pourFrom.RemoveDrink(d);
            }
        }
    }
}
