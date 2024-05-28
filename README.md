A coding challenge about telemetry for Martian robots that I completed in 2021.

Future concerns:
1. Telemetry commands are simple and do not allow for state beyond one command.
   a. You would want to have a more formal command language to enable heartbeats as well as more granular individual commands.
  b. You will want to able to upgrade the software and firmware.
3. How would these commands be sent to Mars.
  a. Over physical telecommunications equipment.
    i. You would want redundancy in the equipment.
  b. You need to deal with a 4 to 24 minute delay in message transit depending on varying distance between earth and mars.
  c. Possibly a long poll from a mars satellite ensuring it is always triggering communication. A secondary ability to send commands when the system stops polling.
4. Bespoke code vs using industry software like events software.
  a. Personally I would want to have full control over every line of code running on Mars and therefore I would build the entire stack.
  b. More thought would be needed to understand how the code should be hosted and if it should be managed or unmanaged.

