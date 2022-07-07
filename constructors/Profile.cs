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
        private string profileName;
        private string sourceDomain;
        private string targetDomain;
        private int type;
        private string name;
        private string state;
        private string details;
        private string largeImage;
        private string largeText;
        private string smallImage;
        private string smallText;
        private bool audible;

        public Profile(int profileId, String profileName, string sourceDomain, string targetDomain, int type, string name, string state, string details, string largeImage, string largeText, string smallImage, string smallText, bool audible)
        {
            this.profileId = profileId;
            this.profileName = profileName;
            this.sourceDomain = sourceDomain;
            this.targetDomain = targetDomain;
            this.type = type;
            this.name = name;
            this.state = state;
            this.details = details;
            this.largeImage = largeImage;
            this.largeText = largeText;
            this.smallImage = smallImage;
            this.smallText = smallText;
            this.audible = audible;
        }

        public int ProfileId
        {
            get { return profileId; }
        }

        public String ProfileName
        {
            get { return profileName; }
        }

        public String SourceDomain
        {
            get { return sourceDomain; }
        }

        public String TargetDomain
        {
            get { return targetDomain; }
        }

        public int Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
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

        public bool Audible
        {
            get { return audible; }
        }

        public override string ToString()
        {
            return ProfileName;
        }

        public string ToString2()
        {
            return "{" + profileId + ", " + profileName + ", " + sourceDomain + ", " + targetDomain + ", " + type + ", " + name + ", " + state + ", " + details + ", " + largeImage + ", " + largeText + ", " + smallImage + ", " + smallText + ", " + audible + "}".Normalize();
        }
    }
}
