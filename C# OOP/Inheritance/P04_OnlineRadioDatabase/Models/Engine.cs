using System;
using System.Collections.Generic;
using System.Text;

namespace P04_OnlineRadioDatabase.Models
{
    public class Engine
    {
        public void Run()
        {
            List<Song> songs = new List<Song>();

            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesCount; i++)
            {
                try
                {
                    string[] inputLine = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                    if (inputLine.Length != 3)
                    {
                        throw new InvalidOperationException("Invalid song.");
                    }

                    string artistName = inputLine[0];
                    string songName = inputLine[1];
                    string songLength = inputLine[2];

                    Song song = new Song(artistName, songName, songLength);

                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Songs added: {songs.Count}");

            long totalPlaylistSeconds = CalculatePlaylistLength(songs);

            TimeSpan timeSpan = TimeSpan.FromSeconds(totalPlaylistSeconds);

            Console.WriteLine($"Playlist length: {timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s");
        }

        private static long CalculatePlaylistLength(List<Song> playlist)
        {
            int seconds = 0;
            int minutes = 0;

            foreach (var song in playlist)
            {
                seconds += song.SongSeconds;
                minutes += song.SongMinutes;
            }

            long totalSeconds = seconds + minutes * 60;
            return totalSeconds;
        }
    }
}
