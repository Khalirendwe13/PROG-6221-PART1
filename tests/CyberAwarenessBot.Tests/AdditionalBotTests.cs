using Xunit;
using CyberAwarenessBot;

namespace CyberAwarenessBot.Tests
{
    public class AdditionalBotTests
    {
        [Theory]
        [InlineData("Tell me about MFA", "MFA")]
        [InlineData("What about two-factor authentication?", "Two-factor")]
        [InlineData("Is public wifi safe?", "public wifi")]
        public void GetResponse_MoreTopics_ReturnsHandled(string query, string expectedKeyword)
        {
            var bot = new Bot();
            var resp = bot.GetResponse(query, out bool handled);
            Assert.True(handled);
            Assert.False(string.IsNullOrWhiteSpace(resp));
        }

        [Fact]
        public void GetResponse_Ransomware_ReturnsAdvice()
        {
            var bot = new Bot();
            var resp = bot.GetResponse("What is ransomware?", out bool handled);
            Assert.True(handled);
            Assert.Contains("ransomware", resp, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
