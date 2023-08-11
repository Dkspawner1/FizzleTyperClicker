using FizzleClicker.Core;
using FizzleClicker.Managers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FizzleClicker.Words
{
    internal class WordManager : FizzleComponent
    {
        private int next = 0;
        internal List<WordGenerator> WordBank;
        internal static List<WordGenerator> ActiveList;
     
        private float currentTime = 0f;
        internal const double SpawnTimeSeconds = 2.25f;
        public override void LoadContent(ContentManager Content) => ActiveList = new();

        public override void Update(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= SpawnTimeSeconds && WordBank.Count > 0)
            {
                next = new Random().Next(WordBank.Count);
                ActiveList.Add(new WordGenerator(WordBank[next].Word));
                ActiveList[ActiveList.Count - 1].Visible = true;
                WordBank.RemoveAt(next);
                currentTime = 0f;
            }

            if(ActiveList.Count > 0) 
            {
                char pressed = InputManager.GetLetter();
                char currentLetter = ActiveList.First().Word.First();

                if (pressed.Equals(currentLetter))
                    ActiveList.First().Word = ActiveList.First().Word.Remove(0, 1);
                if (ActiveList.First().Word == string.Empty)
                    ActiveList.First().Visible = false;
            }

            for (int i = 0; i < ActiveList.Count; i++) 
            {
                WordGenerator word = ActiveList[i];
                word.Update();
                if (!word.Visible && ActiveList.Count >= 1)
                    ActiveList.RemoveAt(i);
            }

            if (ActiveList.Count >= 1 && ActiveList.First().Position.Y >= Data.ScreenHeight + WordBank.First().WordLength.Y)
            {
                ActiveList.First().Visible = false;
                ActiveList.Clear();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var word in ActiveList)
                if (word.Visible)
                    word.Draw(spriteBatch);
        }
        public void PopulateList()
        {
            const string PATH = "wordbank.json";
            WordBank = new List<WordGenerator>();

            if (!File.Exists(PATH))
            {
                var create = File.Create(PATH);
                create.Close();
            }
            var contents = Read<List<string>>(PATH);

            foreach (var line in contents)
                WordBank.Add(new WordGenerator(line));
        
        }
        private T Read<T>(string path) => JsonSerializer.Deserialize<T>(File.ReadAllText(path));
    }
}
