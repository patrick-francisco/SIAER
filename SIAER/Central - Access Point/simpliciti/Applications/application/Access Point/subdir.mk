################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../simpliciti/Applications/application/Access\ Point/main_AP_Async_Listen_autoack.c 

OBJS += \
./simpliciti/Applications/application/Access\ Point/main_AP_Async_Listen_autoack.obj 

C_DEPS += \
./simpliciti/Applications/application/Access\ Point/main_AP_Async_Listen_autoack.pp 

OBJS__QTD += \
".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.obj" 

C_DEPS__QTD += \
".\simpliciti\Applications\application\Access Point\main_AP_Async_Listen_autoack.pp" 

C_SRCS_QUOTED += \
"../simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack.c" 


# Each subdirectory must supply rules for building sources it contributes
simpliciti/Applications/application/Access\ Point/main_AP_Async_Listen_autoack.obj: ../simpliciti/Applications/application/Access\ Point/main_AP_Async_Listen_autoack.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack.pp" >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Applications/application/Access Point" >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Applications/application/Access Point/main_AP_Async_Listen_autoack_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '


