using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace safety_chatbot
{
    public partial class MainWindow : Window
    {
        Random random = new Random();

        Dictionary<string, string> memory = new Dictionary<string, string>();

        Dictionary<string, string[]> responses = new Dictionary<string, string[]>
        {
            {
                "password",
                new[]
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across multiple accounts.",
                    "Enable two-factor authentication for better security."
                }
            },

            {
                "phishing",
                new[]
                {
                    "Never click suspicious email links.",
                    "Always verify the sender before opening attachments.",
                    "Phishing attacks often pretend to be trusted companies."
                }
            },

            {
                "vpn",
                new[]
                {
                    "VPNs help protect your privacy online.",
                    "Use a trusted VPN on public Wi-Fi.",
                    "VPN encrypts your internet traffic."
                }
            },

            {
                "malware",
                new[]
                {
                    "Install antivirus software to stop malware.",
                    "Avoid downloading files from unknown websites.",
                    "Keep your operating system updated."
                }
            },

            {
                "hello",
                new[]
                {
                    "Hello! How can I help you today?",
                    "Welcome to OMNI cybersecurity assistant.",
                    "Hi there! Stay safe online."
                }
            }
        };

        public MainWindow()
        {
            InitializeComponent();

            AddBotMessage("Hello, welcome to Cybersecurity Awareness Month.");
            AddBotMessage("I am OMNI, your cybersecurity assistant.");
            AddBotMessage("How may I help you today?");
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userInput = txtUserInput.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    AddBotMessage("Please type a message.");
                    return;
                }

                AddUserMessage(userInput);

                DetectSentiment(userInput);

                bool foundResponse = false;

                foreach (var item in responses)
                {
                    if (userInput.Contains(item.Key))
                    {
                        string[] possibleResponses = item.Value;

                        string response =
                            possibleResponses[random.Next(possibleResponses.Length)];

                        AddBotMessage(response);

                        memory["last_topic"] = item.Key;

                        foundResponse = true;

                        break;
                    }
                }

                if (!foundResponse)
                {
                    if (memory.ContainsKey("last_topic"))
                    {
                        AddBotMessage(
                            "I am still learning. Last time we discussed " +
                            memory["last_topic"] + ".");
                    }
                    else
                    {
                        AddBotMessage(
                            "I do not understand yet. Ask me about passwords, phishing, VPN, or malware.");
                    }
                }

                txtUserInput.Clear();
            }
            catch (Exception ex)
            {
                AddBotMessage("An error occurred: " + ex.Message);
            }
        }

        private void DetectSentiment(string text)
        {
            if (text.Contains("sad") ||
                text.Contains("angry") ||
                text.Contains("upset"))
            {
                AddBotMessage(
                    "I am sorry you feel that way. Stay safe and take care.");
            }

            if (text.Contains("happy") ||
                text.Contains("good") ||
                text.Contains("great"))
            {
                AddBotMessage(
                    "That is wonderful to hear.");
            }
        }

        private void AddBotMessage(string message)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Foreground = Brushes.LightBlue;

            paragraph.Inlines.Add("OMNI: " + message);

            rtbChat.Document.Blocks.Add(paragraph);

            rtbChat.ScrollToEnd();
        }

        private void AddUserMessage(string message)
        {
            Paragraph paragraph = new Paragraph();

            paragraph.Foreground = Brushes.White;

            paragraph.Inlines.Add("YOU: " + message);

            rtbChat.Document.Blocks.Add(paragraph);

            rtbChat.ScrollToEnd();
        }
    }
}