using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Profile
    {
        private int profileId;
        private string name;
        private string sourceDomain;
        private string targetDomain;
        private string state;
        private string details;
        private string largeImage;
        private string largeText;
        private string smallImage;
        private string smallText;

        public Profile(int profileId, String name, string sourceDomain, string targetDomain, string state, string details, string largeImage, string largeText, string smallImage, string smallText)
        {
            this.profileId = profileId;
            this.name = name;
            this.sourceDomain = sourceDomain;
            this.targetDomain = targetDomain;
            this.state = state;
            this.details = details;
            this.largeImage = largeImage;
            this.largeText = largeText;
            this.smallImage = smallImage;
            this.smallText = smallText;
        }

        public int ProfileId
        {
            get { return profileId; }
        }

        public String Name
        {
            get { return name; }
        }

        public String SourceDomain
        {
            get { return sourceDomain; }
        }

        public String TargetDomain
        {
            get { return targetDomain; }
        }

        public String State
        {
            get { return state; }
        }

        public String Details
        {
            get { return details; }
        }

        public String LargeImage
        {
            get { return largeImage; }
        }

        public String LargeText
        {
            get { return largeText; }
        }

        public String SmallImage
        {
            get { return smallImage; }
        }

        public String SmallText
        {
            get { return smallText; }
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToString2()
        {
            return "{" + profileId + ", " + name + ", " + sourceDomain + ", " + targetDomain + ", " + state + ", " + details + ", " + largeImage + ", " + largeText + ", " + smallImage + ", " + smallText + "}";
        }
    }
}
