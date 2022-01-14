# Motion Lighting

## Lounge Example

### Trigger states
1. Lounge Motion
2. Ambience (Ambient, Bright, Day, Emergency, Evening, Night)
3. Lounge State (Idle, Locked, Manual, Motion)
4. *(Possibly wouldn't need this with the above as manual or locked would cover this sceario)* Lounge Mode (Normal, Reading, Dark, Chill, Television)

### Control Entities
1. Lounge Light
2. Lounge Corner Lamp
3. Lounge Floor Lamp
4. Lounge Motion
5. Sun

### Example of motion detected
1. Motion is detected
2. Ambience is not in (Day, Emergency, Night)
3. State Not In (Locked, Manual)
4. Output state (Idle) => Trigger timer