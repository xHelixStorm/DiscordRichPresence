namespace DiscordRichPresence.enums
{
    /// <summary>
    /// Enum to make all activity types available for Discord rich presence
    /// </summary>
    public enum ActivityType
    {
        Playing = 0,
        Streaming = 1,
        Listening = 2,
        Watching = 3,
        Custom= 4,
        Competing = 5
    };

    public class IActivityType
    {
        private string name = "";
        private int type;

        /// <summary>
        /// Create an object of name and type based on the passed enum value
        /// </summary>
        /// <param name="activity">Enum of type ActivityType required</param>
        public IActivityType(ActivityType activity) {
            this.name = activity.ToString();
            this.type = (int)activity;
        }

        public IActivityType(int type)
        {
            this.name = Enum.GetName(typeof(ActivityType), type);
            this.type = type;
        }

        /// <summary>
        /// Obtain the name of the activity
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Obtain the numeric type of the activity
        /// </summary>
        public int Type
        {
            get { return this.type; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
