using System;

namespace P04_OnlineRadioDatabase.Models
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string length;
        private int songMinutes;
        private int songSeconds;

        public Song(string artistName, string songName, string length)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Length = length;
        }

        public string ArtistName
        {
            get => this.artistName;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidOperationException("Artist name should be between 3 and 20 symbols.");
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get => this.songName;
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidOperationException("Song name should be between 3 and 20 symbols.");
                }

                this.songName = value;
            }
        }

        public string Length
        {
            get => this.length;
            private set
            {
                string[] tokens = value.Split(":");

                if (tokens.Length != 2)
                {
                    throw new InvalidOperationException("Invalid song length.");
                }

                int currMins;
                int currSecs;

                bool isValidMins = int.TryParse(tokens[0], out currMins);
                bool isValidSecs = int.TryParse(tokens[1], out currSecs);

                if ((isValidMins && isValidSecs) == false)
                {
                    throw new InvalidOperationException("Invalid song length.");
                }

                this.length = value;

                SetMinsAndSecs(currMins, currSecs);
            }
        }

        public int SongMinutes
        {
            get => this.songMinutes;
        }

        public int SongSeconds
        {
            get => this.songSeconds;
        }

        private void SetMinsAndSecs(int mins, int secs)
        {
            if (mins < 0 || mins > 14)
            {
                throw new InvalidOperationException("Song minutes should be between 0 and 14.");
            }

            this.songMinutes = mins;

            if (secs < 0 || secs > 59)
            {
                throw new InvalidOperationException("Song seconds should be between 0 and 59.");
            }

            this.songSeconds = secs;
        }
    }
}
