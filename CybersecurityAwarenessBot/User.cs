using System;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Represents a user with automatic properties
    /// </summary>
    public class User
    {
        // Automatic properties (Learning Unit 2 requirement)
        public string Name { get; set; }
        public DateTime SessionStartTime { get; set; }
        public int TopicsLearned { get; set; }
        public bool IsFirstTimeUser { get; set; }

        /// <summary>
        /// Initializes a new user
        /// </summary>
        public User(string name)
        {
            Name = name;
            SessionStartTime = DateTime.Now;
            TopicsLearned = 0;
            IsFirstTimeUser = true;
        }

        /// <summary>
        /// Gets formatted user information
        /// </summary>
        public string GetUserInfo()
        {
            TimeSpan sessionDuration = DateTime.Now - SessionStartTime;
            return $"User: {Name} | Topics Learned: {TopicsLearned} | Session Duration: {sessionDuration.TotalMinutes:F1} minutes";
        }

        /// <summary>
        /// Increments topics learned counter
        /// </summary>
        public void IncrementTopicsLearned()
        {
            TopicsLearned++;
        }

        /// <summary>
        /// Gets personalized welcome message
        /// </summary>
        public string GetWelcomeMessage()
        {
            return IsFirstTimeUser 
                ? $"Welcome, {Name}! I'm here to help you learn about cybersecurity." 
                : $"Welcome back, {Name}! Ready to learn more about staying safe online?";
        }
    }
}

