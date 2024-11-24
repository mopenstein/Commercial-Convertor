# Commercial-Convertor
C# Forms project that bulk converter youtube commercial compilations in preparation for decompiling.

Takes in multiple format video files (mp4,mkv,webm,etc) using FFMPEG in any resolution, checks for black bars on sides, removes them if present, and converts to 640x480 mp4 files.

Use *yt-dlp* to download commercial compilations uploaded to youtube (example: https://youtu.be/Zb5UoN229D0). Add the download videos to the program and click start. Files will be automatically scanned and converted.

You'll need to edit variables *ffmpeg-location* and *temp_folder* to reflect locations on your PC.

Companion program for my Raspberry Pi TV Station Project https://github.com/mopenstein/raspberry_pi_tv_station
