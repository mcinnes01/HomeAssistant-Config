# Node Red Contrib Easing

A node that ramps up a value from a start to an end value using an easing function. Output values are values over time or values within an array.
Typical use cases are smoothing command value changes to avoid large steps.  
![node-appearance](assets/node-appearance.png "Node appearance")  
**Fig. 1:** Node appearance

<a name="installation"></a>
## Installation

<a name="installation_in_node-red"></a>
### In Node-RED
* Via Manage Palette -> Search for "node-red-contrib-easing"

<a name="installation_in_a_shell"></a>
### In a shell
* go to the Node-RED installation folder, in OS X it's usually: `~/.node-red`
* run `npm install node-red-contrib-easing`

<a name="usage"></a>
## Usage

<a name="node_conifguration"></a>
### Node Configuration

![node-settings](assets/node-settings.png "Node properties")  
**Fig. 2:** Node properties

#### Easing function
The transition from the start to the end value follows a functional behaviour. These transiton profiles are divided into three categories depending on the easing function name:
* easeIn...: These are profiles where the starting section is very smooth and the ending section contains a sharp bend.
* easeOut...: These are profiles where the starting section contains a sharp bend and the ending section is very smooth.
* easeInOut...: These are profiles where starting and ending sections are quite smooth.

The behaviour of these three categories is shown by the means of the sinoidal functions in Figure 3.
<img src="assets/easingInOut.png" title="Easing function categories (In, Out, InOut)" width="400" />  
**Fig. 3:** Easing function categories (In, Out, InOut)


Several easing funtions are selectable in the node configuration. These are:
* linear
* 2nd order / parabolic (easeIn, easeOut, easeInOut)
* 3rd order / cubic (easeInCubic, easeOutCubic, easeInOutCubic)
* 4th order (easeInQuart, easeOutQuart, easeInOutQuart)
* 5th order (easeInQuint, easeOutQuint, easeInOutQuint)
* sinusodial (easeInSine, easeOutSine, easeInOutSine)
* exponential (easeInExpo, , easeOutExpo, easeInOutExpo)
* bouncing (bounceIn, bounceOut, bounceInOut)

The profiles of these functions are shown below. See chapter [Transition profiles of the easing functions](#transition_profiles) for details.

<a name="input"></a>
### Input
Depending on the type of the `msg.payload` the `easing` node behaves differently ramping with the selected easing function:
1. **No payload** (empty string)
In the case of an empty string within the `msg.payload`, the `easing` node ramps from 0.0 to 1.0.
2. **Number as payload**
If the `msg.payload` is a number, the `easing` node ramps from its last value to this number given.
3.  **JSON object as payload**
  * If the `msg.payload` contains a JSON object in the format: { "from" : 1, "to" : 10, "duration": 200, "interval" :10 }, it will ramp between these two values (&lt;from&gt;, &lt;to&gt;) within the given &lt;duration&gt; (in milliseconds), outputing a value every &lt;interval&gt; ms.
  * If the `msg.payload` contains a JSON object in the format: { "from" : 1, "to" : 10, "size": 10 }, it will ramp between these two values (&lt;from&gt;, &lt;to&gt;), giving an array of &lt;size&gt; values.
4. Sending a msg with the topic *reset* will cancel any currently running easing function.


<a name="output"></a>
### Output
The output can be configured via the *Output* property within the node configuration to be
* **Values over Time**
  In this case, several `msg` objects are sent, each containing one single value within the `msg.payload`.
* **As Array**
  In this case, one single `msg` is sent, containing an array with all transition profile values within the `msg.payload`.

#### Output - Values over time
This option generates a `msg` sequence.
The duration of this sequence is set by the *Duration* property within the node configuration. The time interval between two `msg` sent is set by the *Interval* property within the node configuration.
The scaling of both values relates to milliseconds (ms).

The number of sent `msg` objects equals to (&lt;Duration&gt; / &lt;Interval&gt;) + 1: The first `msg` object is sent immediately containing the start value (e.g. 0.0), the last `msg` object is sent after &lt;Duration&gt; ms containing the end value (e.g. 1.0).

The 'step height' of every `msg.payload` value depends on the selected easing function. As an example, for the linear case it equals to :  
(&lt;end value&gt; -- &lt;start value&gt;) **&middot;**  &lt;Interval&gt; / &lt;Duration&gt;.  
![Values_over_time](assets/values_over_time.png "Values over time (scaling: Milliseconds)")  
**Fig. 4:** Values over time (&lt;duration&gt;, &lt;interval&gt; in ms)

#### Output - Values in an array
This option generates one single `msg` object. It contains an array [0 .. &lt;Size&gt;] with a selectable number of entries. This number of entries is set by the *Size* property within the node configuration, i.e. the array contains (&lt;Size&gt; + 1) entries.  
![As array](assets/array.png "Node configuration As Array")  
**Fig. 5:** Configuration *As Array*



<a name="further_information"></a>
### Further information
Check Node-REDs info panel to see more information on how to use the easing node.

<a name="example"></a>
## Example
***
**Remark**: Example flows are present in the examples subdirectory. In Node-RED they can be imported via the import function and then selecting *Examples* in the vertical tab menue.
***

The example flow shows the three options of input data via the injecting nodes (option *values over time*).

<img src="assets/flow.png" title="Example flow" width="750" />

[**EasingFlow.json**](examples/EasingFlow.json)  

**Fig. 6:** Easing example

<a name="transition_profiles"></a>
## Transition profiles of the easing functions
The following graphs show the normalized transition profiles the user can select.

<img src="assets/functionsPolynomial.png" title="Polynomial profiles" width="500" />

**Fig. 7:** Polynomial profiles

<img src="assets/functionsSinoideExponential.png" title="Sinoide and exponential profiles" width="500" />

**Fig. 8:** Sinoide and exponential profiles

<img src="assets/functionsBouncing.png" title="Bouncing profiles" width="500" />

**Fig. 9:** Bouncing profiles
