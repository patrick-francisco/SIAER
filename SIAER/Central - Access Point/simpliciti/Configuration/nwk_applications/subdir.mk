################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
C_SRCS += \
../simpliciti/Configuration/nwk_applications/nwk_freq.c \
../simpliciti/Configuration/nwk_applications/nwk_ioctl.c \
../simpliciti/Configuration/nwk_applications/nwk_join.c \
../simpliciti/Configuration/nwk_applications/nwk_link.c \
../simpliciti/Configuration/nwk_applications/nwk_mgmt.c \
../simpliciti/Configuration/nwk_applications/nwk_ping.c \
../simpliciti/Configuration/nwk_applications/nwk_security.c 

OBJS += \
./simpliciti/Configuration/nwk_applications/nwk_freq.obj \
./simpliciti/Configuration/nwk_applications/nwk_ioctl.obj \
./simpliciti/Configuration/nwk_applications/nwk_join.obj \
./simpliciti/Configuration/nwk_applications/nwk_link.obj \
./simpliciti/Configuration/nwk_applications/nwk_mgmt.obj \
./simpliciti/Configuration/nwk_applications/nwk_ping.obj \
./simpliciti/Configuration/nwk_applications/nwk_security.obj 

C_DEPS += \
./simpliciti/Configuration/nwk_applications/nwk_freq.pp \
./simpliciti/Configuration/nwk_applications/nwk_ioctl.pp \
./simpliciti/Configuration/nwk_applications/nwk_join.pp \
./simpliciti/Configuration/nwk_applications/nwk_link.pp \
./simpliciti/Configuration/nwk_applications/nwk_mgmt.pp \
./simpliciti/Configuration/nwk_applications/nwk_ping.pp \
./simpliciti/Configuration/nwk_applications/nwk_security.pp 

OBJS__QTD += \
".\simpliciti\Configuration\nwk_applications\nwk_freq.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_ioctl.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_join.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_link.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_mgmt.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_ping.obj" \
".\simpliciti\Configuration\nwk_applications\nwk_security.obj" 

C_DEPS__QTD += \
".\simpliciti\Configuration\nwk_applications\nwk_freq.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_ioctl.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_join.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_link.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_mgmt.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_ping.pp" \
".\simpliciti\Configuration\nwk_applications\nwk_security.pp" 

C_SRCS_QUOTED += \
"../simpliciti/Configuration/nwk_applications/nwk_freq.c" \
"../simpliciti/Configuration/nwk_applications/nwk_ioctl.c" \
"../simpliciti/Configuration/nwk_applications/nwk_join.c" \
"../simpliciti/Configuration/nwk_applications/nwk_link.c" \
"../simpliciti/Configuration/nwk_applications/nwk_mgmt.c" \
"../simpliciti/Configuration/nwk_applications/nwk_ping.c" \
"../simpliciti/Configuration/nwk_applications/nwk_security.c" 


# Each subdirectory must supply rules for building sources it contributes
simpliciti/Configuration/nwk_applications/nwk_freq.obj: ../simpliciti/Configuration/nwk_applications/nwk_freq.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_freq.pp" >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_freq_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_ioctl.obj: ../simpliciti/Configuration/nwk_applications/nwk_ioctl.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_ioctl.pp" >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_ioctl_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_join.obj: ../simpliciti/Configuration/nwk_applications/nwk_join.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_join.pp" >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_join_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_link.obj: ../simpliciti/Configuration/nwk_applications/nwk_link.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_link.pp" >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_link_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_mgmt.obj: ../simpliciti/Configuration/nwk_applications/nwk_mgmt.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_mgmt.pp" >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_mgmt_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_ping.obj: ../simpliciti/Configuration/nwk_applications/nwk_ping.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_ping.pp" >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_ping_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '

simpliciti/Configuration/nwk_applications/nwk_security.obj: ../simpliciti/Configuration/nwk_applications/nwk_security.c $(GEN_OPTS) $(GEN_SRCS)
	@echo 'Building file: $<'
	@echo 'Invoking: Compiler'
	$(shell echo --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\smpl_nwk_config.dat" --cmd_file="C:\Users\Patrick\SIAER\SIAER\simpliciti\Applications\configuration\Access_Point\smpl_config.dat" > "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo -vmspx >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo -g >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --opt_for_speed=4 >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --define=__CCE__ --define=ACCESS_POINT --define=MRFI_CC430 --define=__CC430F6137__ >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application/Access Point" --include_path="C:/Users/Patrick/SIAER/SIAER/timer" --include_path="C:/Users/Patrick/SIAER/SIAER/random" --include_path="C:/Users/Patrick/SIAER/SIAER/msg" --include_path="C:/Users/Patrick/SIAER/SIAER/project includes" --include_path="C:/Users/Patrick/SIAER/SIAER/uart" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Applications/application" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/nwk_applications" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/smartrf/CC430" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios/family5" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/mrfi/radios" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/mcus" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers/code" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/drivers" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM/bsp_external" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards/CC430EM" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp/boards" --include_path="C:/Users/Patrick/SIAER/SIAER/simpliciti/Configuration/bsp" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/msp430/include" --include_path="C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/include" >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --diag_warning=225 >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --printf_support=minimal >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --preproc_with_compile >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --preproc_dependency="simpliciti/Configuration/nwk_applications/nwk_security.pp" >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(shell echo --obj_directory="simpliciti/Configuration/nwk_applications" >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt")
	$(if $(strip $(GEN_OPTS_QUOTED)), $(shell echo $(GEN_OPTS_QUOTED) >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt"))
	$(if $(strip $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#")), $(shell echo $(subst #,$(wildcard $(subst $(SPACE),\$(SPACE),$<)),"#") >> "simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt"))
	"C:/Program Files (x86)/Texas Instruments/ccsv4/tools/compiler/msp430/bin/cl430" -@"simpliciti/Configuration/nwk_applications/nwk_security_ccsCompiler.opt"
	@echo 'Finished building: $<'
	@echo ' '


