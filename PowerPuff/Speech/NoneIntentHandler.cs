﻿using System.Threading.Tasks;
using Microsoft.Cognitive.LUIS;
using PowerPuff.Common.Speech;

namespace PowerPuff.Speech
{
    public class NoneIntentHandler : IIntentHandler
    {
        private readonly ISpeechSynthesiser _speechSynthesiser;

        public NoneIntentHandler(ISpeechSynthesiser speechSynthesiser)
        {
            _speechSynthesiser = speechSynthesiser;
        }

        [IntentHandler(0, Name = "None")]
        public Task<bool> DefaultHandler(LuisResult result, object context)
        {
            _speechSynthesiser.Speak("I'm sorry, I don't know how to do that.");
            return Task.FromResult(true);
        }
    }
}
