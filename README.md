A coding challenge about telemetry for martian robots that I completed in 2021.

Future concerns:
1. Telemetry commands are simpliest and do not allow for state beyond one command.
  a. You would want to have a more formal command language to enable heartbeats as well as more granular language.
  b. You will want to able to upgrade software and firmware.
2. How would these commands be sent to Mars.
  a. Over telecommmunications equipment
  b. Need to deal with 4-24 miniute delay in message transit depending on varying distance between earth and mars.
  c. Possiibly a long poll from the mars statelite ensuring it is always triggering communication with a secondary ability to send commands.
3. Bespoke code vs using industry software like events software.
  a. Personally I would want to have full control over every line of code runnning on Mars and therefore I would build the entire stack.
  b. More thought would be needed to understand how the code should be hosted and if it should be managed or unmanaged. 
