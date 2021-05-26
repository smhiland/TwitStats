# TwitStats
Statistical data of tweets received

## Configure API access
Supply the API Key, Secret, and Bearer Token in the app.config file of the console application.

## Future Enhancements
Future work will address the architectural and/or functionality deficiencies.

### Emoji Detection
Use a dynamic list of emojis gathered from:
* 3rd party framework
* Embedded file

The emojis will be parsed into a RegEx string to elimitate continual iteration over the list of possible emojis.

### URL Detection
Improve URL RegEx

### Average Stat
Break up into individual stats (hour/min/sec).

### Stats
When a data point is received, throw it into a temp list which will be processed and added to a "final" list. This will avoid reprocessing the data each time the data is pulled.