# Cloud-Player
*This is a gymnasial project for a software engineering course.*

Cloud Player is a media player that attempts to solve the problem of having music (and podcasts or similar) across multple services such as YouTube or SoundCloud. Right now it only supports local media and YouTube, but I would wish to add more in the future. 

Another problem Cloud Player tries to solve is the problem of only having one screen and wanting to watch podcasts (or simply normal videos) while working on something else. On Windows (I wouldn´t know about other OSes) this is a pain in the arse and I generally give up on the idea. And since I have found no other application to do this I want to make an attempt to solve this in Cloud Player aswell.

Things that it does right now:
--------------
- Playlist system is pretty much done.
- Can create or import playlists (from both internal playlists and YouTube; YouTube playlist search works but isn´t as reliable as I would like)
- It plays videos from disk and YouTube. (local: Media Player, YouTube: Youtube´s own player using Awesomuim)
- Video search seem to work pretty nicely (no noticable lag etc...).
- The window will reserve an area on the screen when docking it to a side (currently does not work with Windows own docking system; Alt + (Left|Right) to use; currently does not properly support multiple screens)

Things that I´m working on/ will be worked on (besides bugs and problems mentioned above):
-------------
- WPF conversion (it currently uses WinForms as I did not know WPF when I started this project, but has since begun learning it; current priority)
- An update system that integrates with GitHub.
- Use the video stream from the online services rather than their player.
- A search system for local media.
- Add support for more services (SoundCloud, Twitch...)
