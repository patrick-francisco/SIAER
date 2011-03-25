################################################################################
# Automatically-generated file. Do not edit!
################################################################################

SHELL = cmd.exe

EMPTY := 
SPACE := $(EMPTY) $(EMPTY)

ORDERED_OBJS += \
$(GEN_CMDS_QUOTED) \
"./main.obj" \
"./simpliciti/Components/bsp/bsp.obj" \
"./simpliciti/Components/mrfi/mrfi.obj" \
"./simpliciti/Components/nwk/nwk_globals.obj" \
"./simpliciti/Components/nwk/nwk_frame.obj" \
"./simpliciti/Components/nwk/nwk_api.obj" \
"./simpliciti/Components/nwk/nwk_QMgmt.obj" \
"./simpliciti/Components/nwk/nwk.obj" \
"./simpliciti/Components/nwk_applications/nwk_security.obj" \
"./simpliciti/Components/nwk_applications/nwk_ping.obj" \
"./simpliciti/Components/nwk_applications/nwk_mgmt.obj" \
"./simpliciti/Components/nwk_applications/nwk_link.obj" \
"./simpliciti/Components/nwk_applications/nwk_join.obj" \
"./simpliciti/Components/nwk_applications/nwk_ioctl.obj" \
"./simpliciti/Components/nwk_applications/nwk_freq.obj" \
-l"rts430x.lib" \
"../lnk_cc430f6137.cmd" \

-include ../makefile.init

RM := DEL /F
RMDIR := RMDIR /S/Q

# All of the sources participating in the build are defined here
-include sources.mk
-include subdir.mk
-include simpliciti/Components/nwk_applications/subdir.mk
-include simpliciti/Components/nwk/subdir.mk
-include simpliciti/Components/mrfi/subdir.mk
-include simpliciti/Components/bsp/subdir.mk
-include Components/nwk_applications/subdir.mk
-include Components/nwk/subdir.mk
-include Components/mrfi/subdir.mk
-include Components/bsp/subdir.mk
-include Applications/application/Range\ Extender/subdir.mk
-include Applications/application/End\ Device/subdir.mk
-include Applications/application/Channel\ Sniffer/subdir.mk
-include Applications/application/Access\ Point/subdir.mk
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
all: Project.out

# Tool invocations
Project.out: $(GEN_CMDS) $(CMD_SRCS) $(OBJS)
	@echo 'Building target: $@'
	@echo 'Invoking: Linker'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --diag_warning=225 --printf_support=minimal -z -m"Project.map" --stack_size=80 --heap_size=80 --use_hw_mpy=F5 --warn_sections -i"C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/lib" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --reread_libs --rom_model -o "Project.out" $(ORDERED_OBJS)
	@echo 'Finished building target: $@'
	@echo ' '

# Other Targets
clean:
	-$(RM) $(MSP430_EXECUTABLE_OUTPUTS__QTD) "Project.out"
	-$(RM) ".\simpliciti\Components\nwk_applications\nwk_freq.obj" ".\simpliciti\Components\nwk_applications\nwk_ioctl.obj" ".\simpliciti\Components\nwk_applications\nwk_join.obj" ".\simpliciti\Components\nwk_applications\nwk_link.obj" ".\simpliciti\Components\nwk_applications\nwk_mgmt.obj" ".\simpliciti\Components\nwk_applications\nwk_ping.obj" ".\simpliciti\Components\nwk_applications\nwk_security.obj" ".\simpliciti\Components\nwk\nwk.obj" ".\simpliciti\Components\nwk\nwk_QMgmt.obj" ".\simpliciti\Components\nwk\nwk_api.obj" ".\simpliciti\Components\nwk\nwk_frame.obj" ".\simpliciti\Components\nwk\nwk_globals.obj" ".\simpliciti\Components\mrfi\mrfi.obj" ".\simpliciti\Components\bsp\bsp.obj" ".\main.obj" 
	-$(RM) ".\simpliciti\Components\nwk_applications\nwk_freq.pp" ".\simpliciti\Components\nwk_applications\nwk_ioctl.pp" ".\simpliciti\Components\nwk_applications\nwk_join.pp" ".\simpliciti\Components\nwk_applications\nwk_link.pp" ".\simpliciti\Components\nwk_applications\nwk_mgmt.pp" ".\simpliciti\Components\nwk_applications\nwk_ping.pp" ".\simpliciti\Components\nwk_applications\nwk_security.pp" ".\simpliciti\Components\nwk\nwk.pp" ".\simpliciti\Components\nwk\nwk_QMgmt.pp" ".\simpliciti\Components\nwk\nwk_api.pp" ".\simpliciti\Components\nwk\nwk_frame.pp" ".\simpliciti\Components\nwk\nwk_globals.pp" ".\simpliciti\Components\mrfi\mrfi.pp" ".\simpliciti\Components\bsp\bsp.pp" ".\main.pp" 
	-@echo ' '

.PHONY: all clean dependents
.SECONDARY:

-include ../makefile.targets
