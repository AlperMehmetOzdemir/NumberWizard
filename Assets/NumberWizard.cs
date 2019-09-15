using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{

    int max, min, numberOfGuesses, guess, guessThreshold;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        // Do variable initializations
        max = 1000;
        min = 1;
        numberOfGuesses = 0;
        // Do initial calculations
        guess = (max + min) / 2;
        numberOfGuesses++;
        // Create a threshold that is base 2 logn / 2;
        guessThreshold = (int)Mathf.Log((max - min + 1), 2) / 2;

        // Explain motive of the game
        Debug.Log("Who dares approach the great number wizard!");
        Debug.Log("Choose your number and I shall show you my prowess by finding it out.");
        // Give a range to pick numbers
        Debug.Log("The largest number you can pick is: " + max);
        Debug.Log("The smallest number you can pick is: " + min);
        // Ask for where the picked number is relative to the guess
        Debug.Log("Tell me if yournumber is higher or lower than: " + guess);
        // Give instructions on how the player needs to give input
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
        // Increment max to make sure the max number is inclusive to the guessing range
        max = max + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("It appears I have guessed too low.");
            // Update minimum value
            min = guess;
            // Make a new guess
            NextGuess();
            // Ask for new guess.
            Debug.Log("Tell me if yournumber is higher or lower than: " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("It appears I have guessed too high.");

            // Update maximum value
            max = guess;
            // Make new guess
            NextGuess();

            Debug.Log("Tell me if your number is higher or lower than: " + guess);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Aha! You have witnessed my prowess as I have found that your number is: " + guess);
            // Display win message based on number of guesses
            if (numberOfGuesses < guessThreshold)
            {
                Debug.Log("And it only took me a measly " + numberOfGuesses + " tries!");
            }
            else
            {
                Debug.Log("I see you are quite a wizard as well, you almost made me use an ounce of my power.");
            }

            // Restart Game
            Debug.Log("This has been quite an amusing game.\nLet have another go.");
            StartGame();

        }
    }
    void NextGuess()
    {
        guess = (max + min) / 2;
        numberOfGuesses++;
    }
}
