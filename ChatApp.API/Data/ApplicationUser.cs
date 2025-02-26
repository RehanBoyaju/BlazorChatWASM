using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using ChatApp.API.Data;

namespace ChatApp.API.Data
{
    public class ApplicationUser : IdentityUser
    {
        [JsonIgnore]
        public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }
        public ApplicationUser()
        {
            ChatMessagesFromUsers = new HashSet<ChatMessage>();
            ChatMessagesToUsers = new HashSet<ChatMessage>();
        }
    }
}
