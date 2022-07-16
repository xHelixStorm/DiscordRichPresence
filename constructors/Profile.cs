using DiscordRichPresence.modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordRichPresence.constructors
{
    public class Profile
    {
        private int profileId;
        private string profileName;
        private string sourceUrl;
        private string targetUrl;
        private int type;
        private string name;
        private string state;
        private string details;
        private string largeImage;
        private string largeText;
        private string smallImage;
        private string smallText;
        private string key;
        private bool audible;

        public Profile(int profileId, String profileName, string sourceUrl, string targetUrl, int type, string name, string state, string details, string largeImage, string largeText, string smallImage, string smallText, string key, bool audible)
        {
            this.profileId = profileId;
            this.profileName = profileName;
            this.sourceUrl = sourceUrl;
            this.targetUrl = targetUrl;
            this.type = type;
            this.name = name;
            this.state = state;
            this.details = details;
            this.largeImage = largeImage;
            this.largeText = largeText;
            this.smallImage = smallImage;
            this.smallText = smallText;
            this.key = key;
            this.audible = audible;
        }

        public int ProfileId
        {
            get { return profileId; }
        }

        [Required(ErrorMessage = "Profile Name field is required.")]
        public String ProfileName
        {
            get { return profileName; }
        }

        [Required(ErrorMessage = "Source Domain field is required.")]
        public String SourceUrl
        {
            get { return sourceUrl; }
        }

        public String TargetUrl
        {
            get { return targetUrl; }
        }

        public int Type
        {
            get { return type; }
        }

        [Required(ErrorMessage = "Name field is required.")]
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

        public String Key
        {
            get { return key; }
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
            return "{" + profileId + ", " + profileName + ", " + sourceUrl + ", " + targetUrl + ", " + type + ", " + name + ", " + state + ", " + details + ", " + largeImage + ", " + largeText + ", " + smallImage + ", " + smallText + ", " + key + ", " + audible + "}".Normalize();
        }

        /// <summary>
        /// Validate all required fields.
        /// </summary>
        /// <exception cref="ValidationException">Error when a validation has failed.</exception>
        public void Validate()
        {
            const string urlPattern = @"^(http|https):\/\/[\d\w]{1,}\.[a-z0-9]{2,5}.*$";

            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);
            bool isSourceDomainValid = sourceUrl.Length == 0 || (sourceUrl.Length > 0 && Regex.Match(sourceUrl, urlPattern).Success);
            bool isTargetDomainValid = targetUrl.Length == 0 || (targetUrl.Length > 0 && Regex.Match(targetUrl, urlPattern).Success);

            if (!isValid || !isSourceDomainValid || !isTargetDomainValid)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                if(!isSourceDomainValid)
                {
                    sbrErrors.AppendLine("Invalid url inside of Source Url field.");
                }
                if (!isTargetDomainValid)
                {
                    sbrErrors.AppendLine("Invalid url inside of Target Url field.");
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }
    }
}
