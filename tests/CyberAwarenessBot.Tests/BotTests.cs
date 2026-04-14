using System;
using Xunit;
using CyberAwarenessBot;

namespace CyberAwarenessBot.Tests
{
    public class BotTests
    {
        [Fact]
        public void GetResponse_KnownQuestion_ReturnsAnswer()
        {
            var bot = new Bot { UserName = "Alice" };
            var resp = bot.GetResponse("How are you?", out bool handled);
            Assert.True(handled);
            Assert.Contains("ready to help", resp, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GetResponse_PasswordQuestion_ReturnsPasswordAdvice()
        {
            var bot = new Bot();
            var resp = bot.GetResponse("Tell me about passwords", out bool handled);
            Assert.True(handled);
            Assert.Contains("strong passwords", resp, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GetResponse_UnknownQuestion_ReturnsNotHandled()
        {
            var bot = new Bot();
            var resp = bot.GetResponse("What is the meaning of life?", out bool handled);
            Assert.False(handled);
            Assert.Equal(string.Empty, resp);
        }
    }
}
