<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="FAAS.Azure" generation="1" functional="0" release="0" Id="91bf9f82-82f9-495b-94a2-0c0efb0ad8b3" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="FAAS.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="FAAS:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/FAAS.Azure/FAAS.AzureGroup/LB:FAAS:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="FAAS:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/FAAS.Azure/FAAS.AzureGroup/MapFAAS:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="FAASInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/FAAS.Azure/FAAS.AzureGroup/MapFAASInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:FAAS:Endpoint1">
          <toPorts>
            <inPortMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAAS/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapFAAS:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAAS/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapFAASInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAASInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="FAAS" generation="1" functional="0" release="0" software="C:\Users\cx75\Desktop\Arvind FaaS\FAAS\FAAS.Azure\csx\Release\roles\FAAS" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;FAAS&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;FAAS&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAASInstances" />
            <sCSPolicyUpdateDomainMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAASUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAASFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="FAASUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="FAASFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="FAASInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="1d74c357-bb93-428f-925a-d26e88470b50" ref="Microsoft.RedDog.Contract\ServiceContract\FAAS.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="8832ddc2-7381-413d-aacb-a3f44f12adfd" ref="Microsoft.RedDog.Contract\Interface\FAAS:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/FAAS.Azure/FAAS.AzureGroup/FAAS:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>