################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../main.c 

CMD_SRCS += \
../lnk_cc430f6137.cmd 

OBJS += \
./main.obj 

C_DEPS += \
./main.pp 

OBJS__QTD += \
".\main.obj" 

C_DEPS__QTD += \
".\main.pp" 

C_SRCS_QUOTED += \
"../main.c" 


# Each subdirectory must supply rules for building sources it contributes
main.obj: ../main.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "main_ccsCompiler.opt")
	$(shell echo -vmspx >> "main_ccsCompiler.opt")
	$(shell echo -g >> "main_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "main_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "main_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "main_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "main_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "main_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "main_ccsCompiler.opt")
	$(shell echo --preproc_dependency="main.pp" >> "main_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "main_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "main_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"main_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '


