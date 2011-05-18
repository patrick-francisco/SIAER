################################################################################
# Automatically-generated file. Do not edit!
################################################################################

SHELL = cmd.exe

EMPTY := 
SPACE := $(EMPTY) $(EMPTY)

ORDERED_OBJS += \
$(GEN_CMDS_QUOTED) \
"./main.obj" \
"./msg/msg.obj" \
"./simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack.obj" \
"./simpliciti/Applications/application/End Device/main_manyEDs_autoack.obj" \
"./simpliciti/Configuration/bsp/bsp.obj" \
"./simpliciti/Configuration/mrfi/mrfi.obj" \
"./simpliciti/Configuration/nwk/nwk_globals.obj" \
"./simpliciti/Configuration/nwk/nwk_frame.obj" \
"./simpliciti/Configuration/nwk/nwk_api.obj" \
"./simpliciti/Configuration/nwk/nwk_QMgmt.obj" \
"./simpliciti/Configuration/nwk/nwk.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_security.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_ping.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_mgmt.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_link.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_join.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_ioctl.obj" \
"./simpliciti/Configuration/nwk_applications/nwk_freq.obj" \
"./timer/timer.obj" \
"./uart/uart.obj" \
-l"libc.a" \
"../lnk_cc430f6137.cmd" \

-include ../makefile.init

RM := DEL /F
RMDIR := RMDIR /S/Q

# All of the sources participating in the build are defined here
-include sources.mk
-include subdir.mk
-include uart/subdir.mk
-include timer/subdir.mk
-include simpliciti/Configuration/nwk_applications/subdir.mk
-include simpliciti/Configuration/nwk/subdir.mk
-include simpliciti/Configuration/mrfi/subdir.mk
-include simpliciti/Configuration/bsp/subdir.mk
-include simpliciti/Applications/application/End\ Device/subdir.mk
-include simpliciti/Applications/application/Access\ Point/subdir.mk
-include msg/subdir.mk
-include objects.mk

ifneq ($(MAKECMDGOALS),clean)
ifneq ($(strip $(S62_DEPS)),)
-include $(S62_DEPS)
endif
ifneq ($(strip $(ASM_DEPS)),)
-include $(ASM_DEPS)
endif
ifneq ($(strip $(C55_DEPS)),)
-include $(C55_DEPS)
endif
ifneq ($(strip $(S_UPPER_DEPS)),)
-include $(S_UPPER_DEPS)
endif
ifneq ($(strip $(C++_DEPS)),)
-include $(C++_DEPS)
endif
ifneq ($(strip $(S_DEPS)),)
-include $(S_DEPS)
endif
ifneq ($(strip $(CC_DEPS)),)
-include $(CC_DEPS)
endif
ifneq ($(strip $(C64_DEPS)),)
-include $(C64_DEPS)
endif
ifneq ($(strip $(CPP_DEPS)),)
-include $(CPP_DEPS)
endif
ifneq ($(strip $(S64_DEPS)),)
-include $(S64_DEPS)
endif
ifneq ($(strip $(CXX_DEPS)),)
-include $(CXX_DEPS)
endif
ifneq ($(strip $(C67_DEPS)),)
-include $(C67_DEPS)
endif
ifneq ($(strip $(S67_DEPS)),)
-include $(S67_DEPS)
endif
ifneq ($(strip $(S43_DEPS)),)
-include $(S43_DEPS)
endif
ifneq ($(strip $(C62_DEPS)),)
-include $(C62_DEPS)
endif
ifneq ($(strip $(C43_DEPS)),)
-include $(C43_DEPS)
endif
ifneq ($(strip $(C??_DEPS)),)
-include $(C??_DEPS)
endif
ifneq ($(strip $(ASM_UPPER_DEPS)),)
-include $(ASM_UPPER_DEPS)
endif
ifneq ($(strip $(OPT_DEPS)),)
-include $(OPT_DEPS)
endif
ifneq ($(strip $(S??_DEPS)),)
-include $(S??_DEPS)
endif
ifneq ($(strip $(S55_DEPS)),)
-include $(S55_DEPS)
endif
ifneq ($(strip $(C_DEPS)),)
-include $(C_DEPS)
endif
ifneq ($(strip $(SA_DEPS)),)
-include $(SA_DEPS)
endif
ifneq ($(strip $(C_UPPER_DEPS)),)
-include $(C_UPPER_DEPS)
endif
endif

-include ../makefile.defs

# Add inputs and outputs from these tool invocations to the build variables 

# All Target
all: SIAER.out

# Tool invocations
SIAER.out: $(GEN_CMDS) $(CMD_SRCS) $(OBJS)
	@echo 'Building target: $@'
	@echo 'Invoking: Linker'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\End_Device\smpl_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g -O2 --define=__CCE__ --define=END_DEVICE --define=MRFI_CC430 --define=__CC430F6137__ --diag_warning=225 --printf_support=minimal -z -m"SIAER.map" --stack_size=80 --heap_size=80 --use_hw_mpy=F5 --warn_sections -i"C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/lib" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --reread_libs --rom_model -o "SIAER.out" $(ORDERED_OBJS)
	@echo 'Finished building target: $@'
	@echo ' '

# Other Targets
clean:
	-$(RM) $(MSP430_EXECUTABLE_OUTPUTS__QTD) "SIAER.out"
	-$(RM) ".\uart\uart.obj" ".\timer\timer.obj" ".\simpliciti\Configuration\nwk_applications\nwk_freq.obj" ".\simpliciti\Configuration\nwk_applications\nwk_ioctl.obj" ".\simpliciti\Configuration\nwk_applications\nwk_join.obj" ".\simpliciti\Configuration\nwk_applications\nwk_link.obj" ".\simpliciti\Configuration\nwk_applications\nwk_mgmt.obj" ".\simpliciti\Configuration\nwk_applications\nwk_ping.obj" ".\simpliciti\Configuration\nwk_applications\nwk_security.obj" ".\simpliciti\Configuration\nwk\nwk.obj" ".\simpliciti\Configuration\nwk\nwk_QMgmt.obj" ".\simpliciti\Configuration\nwk\nwk_api.obj" ".\simpliciti\Configuration\nwk\nwk_frame.obj" ".\simpliciti\Configuration\nwk\nwk_globals.obj" ".\simpliciti\Configuration\mrfi\mrfi.obj" ".\simpliciti\Configuration\bsp\bsp.obj" ".\simpliciti\Applications\application\End Device\main_manyEDs_autoack.obj" ".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.obj" ".\msg\msg.obj" ".\main.obj" 
	-$(RM) ".\uart\uart.pp" ".\timer\timer.pp" ".\simpliciti\Configuration\nwk_applications\nwk_freq.pp" ".\simpliciti\Configuration\nwk_applications\nwk_ioctl.pp" ".\simpliciti\Configuration\nwk_applications\nwk_join.pp" ".\simpliciti\Configuration\nwk_applications\nwk_link.pp" ".\simpliciti\Configuration\nwk_applications\nwk_mgmt.pp" ".\simpliciti\Configuration\nwk_applications\nwk_ping.pp" ".\simpliciti\Configuration\nwk_applications\nwk_security.pp" ".\simpliciti\Configuration\nwk\nwk.pp" ".\simpliciti\Configuration\nwk\nwk_QMgmt.pp" ".\simpliciti\Configuration\nwk\nwk_api.pp" ".\simpliciti\Configuration\nwk\nwk_frame.pp" ".\simpliciti\Configuration\nwk\nwk_globals.pp" ".\simpliciti\Configuration\mrfi\mrfi.pp" ".\simpliciti\Configuration\bsp\bsp.pp" ".\simpliciti\Applications\application\End Device\main_manyEDs_autoack.pp" ".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.pp" ".\msg\msg.pp" ".\main.pp" 
	-@echo ' '

.PHONY: all clean dependents
.SECONDARY:

-include ../makefile.targets
