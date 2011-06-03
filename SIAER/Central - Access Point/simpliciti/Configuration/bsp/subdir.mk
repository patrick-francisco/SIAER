################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../simpliciti/Configuration/bsp/bsp.c 

OBJS += \
./simpliciti/Configuration/bsp/bsp.obj 

C_DEPS += \
./simpliciti/Configuration/bsp/bsp.pp 

OBJS__QTD += \
".\simpliciti\Configuration\bsp\bsp.obj" 

C_DEPS__QTD += \
".\simpliciti\Configuration\bsp\bsp.pp" 

C_SRCS_QUOTED += \
"../simpliciti/Configuration/bsp/bsp.c" 


# Each subdirectory must supply rules for building sources it contributes
simpliciti/Configuration/bsp/bsp.obj: ../simpliciti/Configuration/bsp/bsp.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/bsp/bsp.pp" >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/bsp" >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/bsp/bsp_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/bsp/bsp_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '


