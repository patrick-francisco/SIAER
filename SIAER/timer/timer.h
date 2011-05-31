#ifndef TIMER_H_
#define TIMER_H_

// *************************************************************************************************
// Include section

// *************************************************************************************************
// Prototypes section
extern void Timer1_Init(void);
extern void Timer1_Start(void);
extern void Timer1_Stop(void);
extern void Timer0_A4_Delay(unsigned short ticks);

extern char delay_over;
// *************************************************************************************************
// Defines section

// *************************************************************************************************
// Global Variable section

// *************************************************************************************************
// Extern section

#endif                          /*TIMER_H_ */
