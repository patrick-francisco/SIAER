################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../simpliciti/Components/bsp/bsp.c 

OBJS += \
./simpliciti/Components/bsp/bsp.obj 

C_DEPS += \
./simpliciti/Components/bsp/bsp.pp 

OBJS__QTD += \
".\simpliciti\Components\bsp\bsp.obj" 

C_DEPS__QTD += \
".\simpliciti\Components\bsp\bsp.pp" 

C_SRCS_QUOTED += \
"../simpliciti/Components/bsp/bsp.c" 


# Each subdirectory must supply rules for building sources it contributes
simpliciti/Components/bsp/bsp.obj: ../simpliciti/Components/bsp/bsp.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\Access Point\smpl_config.dat" --cmd_file="C:\Users\Patrick\Downloads\_PROJETO FINAL\Software\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat"  -vmspx -g --define=__CC430F6137__ --define=_CCE_ --define=MRFI_CC430 --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --diag_warning=225 --printf_support=minimal --preproc_with_compile --preproc_dependency="simpliciti/Components/bsp/bsp.pp" --obj_directory="simpliciti/Components/bsp" $(GEN_OPTS_QUOTED) $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")
	@echo 'Finished building: $<'
	@echo ' '


