﻿namespace Runemark.DialogueSystem.UI
{
    using System.Collections.Generic;

    public enum DialogueUIType { Conversation, AmbientDialogue }

    /// <summary>
    /// Interface class for ui controller.
    /// </summary>
	public interface IDialogueUIController
	{
        DialogueBehaviour behavior { get; }

        string DefaultSkin { get; set;  }


        void OnDialogueStart(DialogueBehaviour owner);

        /// <summary>
        /// Show the specified text and answers.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="answers">Answers.</param>
        void OnTextChanged(DialogueFlow dialogue, TextData text, List<TextAnswerData> answers, SettingsData settings);

		/// <summary>
		/// Close this dialogue.
		/// </summary>
		void OnDialogueFinished(DialogueBehaviour owner);

		/// <summary>
		/// Raises the answer selected event.
		/// </summary>
		/// <param name="id">Identifier.</param>
		void OnAnswerSelected(string id);

        System.Action onApplicationQuit { get; set; }
        System.Action onInactivated { get; set; }
    }
}