################################################################################
# Automatically-generated file. Do not edit!
################################################################################

SHELL = cmd.exe

EMPTY := 
SPACE := $(EMPTY) $(EMPTY)

ORDERED_OBJS += \
$(GEN_CMDS_QUOTED) \
"./main.obj" \
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
-include simpliciti/Configuration/nwk_applications/subdir.mk
-include simpliciti/Configuration/nwk/subdir.mk
-include simpliciti/Configuration/mrfi/subdir.mk
-include simpliciti/Configuration/bsp/subdir.mk
-include simpliciti/Applications/application/End\ Device/subdir.mk
-include simpliciti/Applications/application/Access\ Point/subdir.mk
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
	$(shell echo --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\project\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\project\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "ccsLinker.opt")
	$(shell echo -vmspx >> "ccsLinker.opt")
	$(shell echo -g >> "ccsLinker.opt")
	$(shell echo -O2 >> "ccsLinker.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "ccsLinker.opt")
	$(shell echo --diag_warning=225 >> "ccsLinker.opt")
	$(shell echo --printf_support=minimal >> "ccsLinker.opt")
	$(shell echo -z >> "ccsLinker.opt")
	$(shell echo -m"SIAER.map" >> "ccsLinker.opt")
	$(shell echo --stack_size=80 >> "ccsLinker.opt")
	$(shell echo --heap_size=80 >> "ccsLinker.opt")
	$(shell echo --use_hw_mpy=F5 >> "ccsLinker.opt")
	$(shell echo --warn_sections >> "ccsLinker.opt")
	$(shell echo -i"C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/lib" -i"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "ccsLinker.opt")
	$(shell echo --reread_libs >> "ccsLinker.opt")
	$(shell echo --rom_model >> "ccsLinker.opt")
	$(shell type "ccsObjs.opt" >> "ccsLinker.opt")
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"ccsLinker.opt" -o "SIAER.out"
	@echo 'Finished building target: $@'
	@echo ' '

# Other Targets
clean:
	-$(RM) $(MSP430_EXECUTABLE_OUTPUTS__QTD) "SIAER.out"
	-$(RM) ".\uart\uart.obj" ".\simpliciti\Configuration\nwk_applications\nwk_freq.obj" ".\simpliciti\Configuration\nwk_applications\nwk_ioctl.obj" ".\simpliciti\Configuration\nwk_applications\nwk_join.obj" ".\simpliciti\Configuration\nwk_applications\nwk_link.obj" ".\simpliciti\Configuration\nwk_applications\nwk_mgmt.obj" ".\simpliciti\Configuration\nwk_applications\nwk_ping.obj" ".\simpliciti\Configuration\nwk_applications\nwk_security.obj" ".\simpliciti\Configuration\nwk\nwk.obj" ".\simpliciti\Configuration\nwk\nwk_QMgmt.obj" ".\simpliciti\Configuration\nwk\nwk_api.obj" ".\simpliciti\Configuration\nwk\nwk_frame.obj" ".\simpliciti\Configuration\nwk\nwk_globals.obj" ".\simpliciti\Configuration\mrfi\mrfi.obj" ".\simpliciti\Configuration\bsp\bsp.obj" ".\simpliciti\Applications\application\End Device\main_manyEDs_autoack.obj" ".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.obj" ".\main.obj" 
	-$(RM) ".\uart\uart.pp" ".\simpliciti\Configuration\nwk_applications\nwk_freq.pp" ".\simpliciti\Configuration\nwk_applications\nwk_ioctl.pp" ".\simpliciti\Configuration\nwk_applications\nwk_join.pp" ".\simpliciti\Configuration\nwk_applications\nwk_link.pp" ".\simpliciti\Configuration\nwk_applications\nwk_mgmt.pp" ".\simpliciti\Configuration\nwk_applications\nwk_ping.pp" ".\simpliciti\Configuration\nwk_applications\nwk_security.pp" ".\simpliciti\Configuration\nwk\nwk.pp" ".\simpliciti\Configuration\nwk\nwk_QMgmt.pp" ".\simpliciti\Configuration\nwk\nwk_api.pp" ".\simpliciti\Configuration\nwk\nwk_frame.pp" ".\simpliciti\Configuration\nwk\nwk_globals.pp" ".\simpliciti\Configuration\mrfi\mrfi.pp" ".\simpliciti\Configuration\bsp\bsp.pp" ".\simpliciti\Applications\application\End Device\main_manyEDs_autoack.pp" ".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.pp" ".\main.pp" 
	-@echo ' '

.PHONY: all clean dependents
.SECONDARY:

-include ../makefile.targets
