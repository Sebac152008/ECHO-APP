# Culture = "en-US"
ConvertFrom-StringData @'
###PSLOC
    PromptYesString = &Yes
    PromptNoString = &No
    BundleFound = Found bundle: {0}
    PackageFound = Found package: {0}
    EncryptedBundleFound = Found encrypted bundle: {0}
    EncryptedPackageFound = Found encrypted package: {0}
    CertificateFound = Found certificate: {0}
    DependenciesFound = Found dependency package(s):
    GettingDeveloperLicense = Acquiring developer license...
    InstallingCertificate = Installing certificate...
    InstallingPackage = \nInstalling app...
    AcquireLicenseSuccessful = A developer license was successfully acquired.
    InstallCertificateSuccessful = The certificate was successfully installed.
    Success = \nSuccess: Your app was successfully installed.
    WarningInstallCert = \nYou are about to install a digital certificate to your computer's Trusted People certificate store. Doing so carries serious security risk and should only be done if you trust the originator of this digital certificate.\n\nWhen you are done using this app, you should manually remove the associated digital certificate. Instructions for doing so can be found here: http://go.microsoft.com/fwlink/?LinkId=243053\n\nAre you sure you wish to continue?\n\n
    ElevateActions = \nBefore installing this app, you need to do the following:
    ElevateActionDevLicense = \t- Acquire a developer license
    ElevateActionCertificate = \t- Install the signing certificate
    ElevateActionsContinue = Administrator credentials are required to continue.  Please accept the UAC prompt and provide your administrator password if asked.
    ErrorForceElevate = You must provide administrator credentials to proceed.  Please run this script without the -Force parameter or from an elevated PowerShell window.
    ErrorForceDeveloperLicense = Acquiring a developer license requires user interaction.  Please rerun the script without the -Force parameter.
    ErrorLaunchAdminFailed = Error: Could not start a new process as administrator.
    ErrorNoScriptPath = Error: You must launch this script from a file.
    ErrorNoPackageFound = Error: No package or bundle found in the script directory.  Please make sure the package or bundle you want to install is placed in the same directory as this script.
    ErrorManyPackagesFound = Error: More than one package or bundle found in the script directory.  Please make sure only the package or bundle you want to install is placed in the same directory as this script.
    ErrorPackageUnsigned = Error: The package or bundle is not digitally signed or its signature is corrupted.
    ErrorNoCertificateFound = Error: No certificate found in the script directory.  Please make sure the certificate used to sign the package or bundle you are installing is placed in the same directory as this script.
    ErrorManyCertificatesFound = Error: More than one certificate found in the script directory.  Please make sure only the certificate used to sign the package or bundle you are installing is placed in the same directory as this script.
    ErrorBadCertificate = Error: The file "{0}" is not a valid digital certificate.  CertUtil returned with error code {1}.
    ErrorExpiredCertificate = Error: The developer certificate "{0}" has expired. One possible cause is the system clock isn't set to the correct date and time. If the system settings are correct, contact the app owner to re-create a package or bundle with a valid certificate.
    ErrorCertificateMismatch = Error: The certificate does not match the one used to sign the package or bundle.
    ErrorCertIsCA = Error: The certificate can't be a certificate authority.
    ErrorBannedKeyUsage = Error: The certificate can't have the following key usage: {0}.  Key usage must be unspecified or equal to "DigitalSignature".
    ErrorBannedEKU = Error: The certificate can't have the following extended key usage: {0}.  Only the Code Signing and Lifetime Signing EKUs are allowed.
    ErrorNoBasicConstraints = Error: The certificate is missing the basic constraints extension.
    ErrorNoCodeSigningEku = Error: The certificate is missing the extended key usage for Code Signing.
    ErrorInstallCertificateCancelled = Error: Installation of the certificate was cancelled.
    ErrorCertUtilInstallFailed = Error: Could not install the certificate.  CertUtil returned with error code {0}.
    ErrorGetDeveloperLicenseFailed = Error: Could not acquire a developer license. For more information, see http://go.microsoft.com/fwlink/?LinkID=252740.
    ErrorInstallCertificateFailed = Error: Could not install the certificate. Status: {0}. For more information, see http://go.microsoft.com/fwlink/?LinkID=252740.
    ErrorAddPackageFailed = Error: Could not install the app.
    ErrorAddPackageFailedWithCert = Error: Could not install the app.  To ensure security, please consider uninstalling the signing certificate until you can install the app.  Instructions for doing so can be found here:\nhttp://go.microsoft.com/fwlink/?LinkId=243053
'@

# SIG # Begin signature block
# MIInzQYJKoZIhvcNAQcCoIInvjCCJ7oCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCAWMAwj/rusIg89
# 0IGBsfgw5LEy+D8tMq94MTciF3t/PaCCDYUwggYDMIID66ADAgECAhMzAAADri01
# UchTj1UdAAAAAAOuMA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25p
# bmcgUENBIDIwMTEwHhcNMjMxMTE2MTkwODU5WhcNMjQxMTE0MTkwODU5WjB0MQsw
# CQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9u
# ZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMR4wHAYDVQQDExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB
# AQD0IPymNjfDEKg+YyE6SjDvJwKW1+pieqTjAY0CnOHZ1Nj5irGjNZPMlQ4HfxXG
# yAVCZcEWE4x2sZgam872R1s0+TAelOtbqFmoW4suJHAYoTHhkznNVKpscm5fZ899
# QnReZv5WtWwbD8HAFXbPPStW2JKCqPcZ54Y6wbuWV9bKtKPImqbkMcTejTgEAj82
# 6GQc6/Th66Koka8cUIvz59e/IP04DGrh9wkq2jIFvQ8EDegw1B4KyJTIs76+hmpV
# M5SwBZjRs3liOQrierkNVo11WuujB3kBf2CbPoP9MlOyyezqkMIbTRj4OHeKlamd
# WaSFhwHLJRIQpfc8sLwOSIBBAgMBAAGjggGCMIIBfjAfBgNVHSUEGDAWBgorBgEE
# AYI3TAgBBggrBgEFBQcDAzAdBgNVHQ4EFgQUhx/vdKmXhwc4WiWXbsf0I53h8T8w
# VAYDVR0RBE0wS6RJMEcxLTArBgNVBAsTJE1pY3Jvc29mdCBJcmVsYW5kIE9wZXJh
# dGlvbnMgTGltaXRlZDEWMBQGA1UEBRMNMjMwMDEyKzUwMTgzNjAfBgNVHSMEGDAW
# gBRIbmTlUAXTgqoXNzcitW2oynUClTBUBgNVHR8ETTBLMEmgR6BFhkNodHRwOi8v
# d3d3Lm1pY3Jvc29mdC5jb20vcGtpb3BzL2NybC9NaWNDb2RTaWdQQ0EyMDExXzIw
# MTEtMDctMDguY3JsMGEGCCsGAQUFBwEBBFUwUzBRBggrBgEFBQcwAoZFaHR0cDov
# L3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9jZXJ0cy9NaWNDb2RTaWdQQ0EyMDEx
# XzIwMTEtMDctMDguY3J0MAwGA1UdEwEB/wQCMAAwDQYJKoZIhvcNAQELBQADggIB
# AGrJYDUS7s8o0yNprGXRXuAnRcHKxSjFmW4wclcUTYsQZkhnbMwthWM6cAYb/h2W
# 5GNKtlmj/y/CThe3y/o0EH2h+jwfU/9eJ0fK1ZO/2WD0xi777qU+a7l8KjMPdwjY
# 0tk9bYEGEZfYPRHy1AGPQVuZlG4i5ymJDsMrcIcqV8pxzsw/yk/O4y/nlOjHz4oV
# APU0br5t9tgD8E08GSDi3I6H57Ftod9w26h0MlQiOr10Xqhr5iPLS7SlQwj8HW37
# ybqsmjQpKhmWul6xiXSNGGm36GarHy4Q1egYlxhlUnk3ZKSr3QtWIo1GGL03hT57
# xzjL25fKiZQX/q+II8nuG5M0Qmjvl6Egltr4hZ3e3FQRzRHfLoNPq3ELpxbWdH8t
# Nuj0j/x9Crnfwbki8n57mJKI5JVWRWTSLmbTcDDLkTZlJLg9V1BIJwXGY3i2kR9i
# 5HsADL8YlW0gMWVSlKB1eiSlK6LmFi0rVH16dde+j5T/EaQtFz6qngN7d1lvO7uk
# 6rtX+MLKG4LDRsQgBTi6sIYiKntMjoYFHMPvI/OMUip5ljtLitVbkFGfagSqmbxK
# 7rJMhC8wiTzHanBg1Rrbff1niBbnFbbV4UDmYumjs1FIpFCazk6AADXxoKCo5TsO
# zSHqr9gHgGYQC2hMyX9MGLIpowYCURx3L7kUiGbOiMwaMIIHejCCBWKgAwIBAgIK
# YQ6Q0gAAAAAAAzANBgkqhkiG9w0BAQsFADCBiDELMAkGA1UEBhMCVVMxEzARBgNV
# BAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jv
# c29mdCBDb3Jwb3JhdGlvbjEyMDAGA1UEAxMpTWljcm9zb2Z0IFJvb3QgQ2VydGlm
# aWNhdGUgQXV0aG9yaXR5IDIwMTEwHhcNMTEwNzA4MjA1OTA5WhcNMjYwNzA4MjEw
# OTA5WjB+MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UE
# BxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSgwJgYD
# VQQDEx9NaWNyb3NvZnQgQ29kZSBTaWduaW5nIFBDQSAyMDExMIICIjANBgkqhkiG
# 9w0BAQEFAAOCAg8AMIICCgKCAgEAq/D6chAcLq3YbqqCEE00uvK2WCGfQhsqa+la
# UKq4BjgaBEm6f8MMHt03a8YS2AvwOMKZBrDIOdUBFDFC04kNeWSHfpRgJGyvnkmc
# 6Whe0t+bU7IKLMOv2akrrnoJr9eWWcpgGgXpZnboMlImEi/nqwhQz7NEt13YxC4D
# dato88tt8zpcoRb0RrrgOGSsbmQ1eKagYw8t00CT+OPeBw3VXHmlSSnnDb6gE3e+
# lD3v++MrWhAfTVYoonpy4BI6t0le2O3tQ5GD2Xuye4Yb2T6xjF3oiU+EGvKhL1nk
# kDstrjNYxbc+/jLTswM9sbKvkjh+0p2ALPVOVpEhNSXDOW5kf1O6nA+tGSOEy/S6
# A4aN91/w0FK/jJSHvMAhdCVfGCi2zCcoOCWYOUo2z3yxkq4cI6epZuxhH2rhKEmd
# X4jiJV3TIUs+UsS1Vz8kA/DRelsv1SPjcF0PUUZ3s/gA4bysAoJf28AVs70b1FVL
# 5zmhD+kjSbwYuER8ReTBw3J64HLnJN+/RpnF78IcV9uDjexNSTCnq47f7Fufr/zd
# sGbiwZeBe+3W7UvnSSmnEyimp31ngOaKYnhfsi+E11ecXL93KCjx7W3DKI8sj0A3
# T8HhhUSJxAlMxdSlQy90lfdu+HggWCwTXWCVmj5PM4TasIgX3p5O9JawvEagbJjS
# 4NaIjAsCAwEAAaOCAe0wggHpMBAGCSsGAQQBgjcVAQQDAgEAMB0GA1UdDgQWBBRI
# bmTlUAXTgqoXNzcitW2oynUClTAZBgkrBgEEAYI3FAIEDB4KAFMAdQBiAEMAQTAL
# BgNVHQ8EBAMCAYYwDwYDVR0TAQH/BAUwAwEB/zAfBgNVHSMEGDAWgBRyLToCMZBD
# uRQFTuHqp8cx0SOJNDBaBgNVHR8EUzBRME+gTaBLhklodHRwOi8vY3JsLm1pY3Jv
# c29mdC5jb20vcGtpL2NybC9wcm9kdWN0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFf
# MDNfMjIuY3JsMF4GCCsGAQUFBwEBBFIwUDBOBggrBgEFBQcwAoZCaHR0cDovL3d3
# dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFf
# MDNfMjIuY3J0MIGfBgNVHSAEgZcwgZQwgZEGCSsGAQQBgjcuAzCBgzA/BggrBgEF
# BQcCARYzaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9kb2NzL3ByaW1h
# cnljcHMuaHRtMEAGCCsGAQUFBwICMDQeMiAdAEwAZQBnAGEAbABfAHAAbwBsAGkA
# YwB5AF8AcwB0AGEAdABlAG0AZQBuAHQALiAdMA0GCSqGSIb3DQEBCwUAA4ICAQBn
# 8oalmOBUeRou09h0ZyKbC5YR4WOSmUKWfdJ5DJDBZV8uLD74w3LRbYP+vj/oCso7
# v0epo/Np22O/IjWll11lhJB9i0ZQVdgMknzSGksc8zxCi1LQsP1r4z4HLimb5j0b
# pdS1HXeUOeLpZMlEPXh6I/MTfaaQdION9MsmAkYqwooQu6SpBQyb7Wj6aC6VoCo/
# KmtYSWMfCWluWpiW5IP0wI/zRive/DvQvTXvbiWu5a8n7dDd8w6vmSiXmE0OPQvy
# CInWH8MyGOLwxS3OW560STkKxgrCxq2u5bLZ2xWIUUVYODJxJxp/sfQn+N4sOiBp
# mLJZiWhub6e3dMNABQamASooPoI/E01mC8CzTfXhj38cbxV9Rad25UAqZaPDXVJi
# hsMdYzaXht/a8/jyFqGaJ+HNpZfQ7l1jQeNbB5yHPgZ3BtEGsXUfFL5hYbXw3MYb
# BL7fQccOKO7eZS/sl/ahXJbYANahRr1Z85elCUtIEJmAH9AAKcWxm6U/RXceNcbS
# oqKfenoi+kiVH6v7RyOA9Z74v2u3S5fi63V4GuzqN5l5GEv/1rMjaHXmr/r8i+sL
# gOppO6/8MO0ETI7f33VtY5E90Z1WTk+/gFcioXgRMiF670EKsT/7qMykXcGhiJtX
# cVZOSEXAQsmbdlsKgEhr/Xmfwb1tbWrJUnMTDXpQzTGCGZ4wghmaAgEBMIGVMH4x
# CzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRt
# b25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01p
# Y3Jvc29mdCBDb2RlIFNpZ25pbmcgUENBIDIwMTECEzMAAAOuLTVRyFOPVR0AAAAA
# A64wDQYJYIZIAWUDBAIBBQCgga4wGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQw
# HAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwLwYJKoZIhvcNAQkEMSIEIE8B
# kX4I7W6bV9BLoLzUR1qESo/bvrTAJuxrExxafO8QMEIGCisGAQQBgjcCAQwxNDAy
# oBSAEgBNAGkAYwByAG8AcwBvAGYAdKEagBhodHRwOi8vd3d3Lm1pY3Jvc29mdC5j
# b20wDQYJKoZIhvcNAQEBBQAEggEAqXYM1oV/pOGuyEAx9hWnJUiTGYP/FdJmS804
# ZECwYd8Rn5oU5a7MPPQZAi5TEvr5T4a+8KwzXmPjPWhYjChPmesZotb8oSAJEz3B
# I2/zGzinVCsY37Hv1lP3WxtKb6CEIkq/0NWEBCcHlAoIoac0vY3IltB7NRl43sAd
# 7OINulxArbmW2uEym8IX4JOG+CGyT0g8YSKFSxyp+1bnZeAY6Vdl3ILwGeNs2GAY
# MunPDxF0r55+r1RcC+5gJAfALUXWUN94wnseSzBute7uOMKVDqhGg+Cs1ucKF9CB
# +nOnD/c7wJK8Ng2wR8T796cUJgO5L/A7N2ZLll2GZ7tL14FvXaGCFygwghckBgor
# BgEEAYI3AwMBMYIXFDCCFxAGCSqGSIb3DQEHAqCCFwEwghb9AgEDMQ8wDQYJYIZI
# AWUDBAIBBQAwggFZBgsqhkiG9w0BCRABBKCCAUgEggFEMIIBQAIBAQYKKwYBBAGE
# WQoDATAxMA0GCWCGSAFlAwQCAQUABCDxtfbK+HrzDQZJQ0vFSBXt6vAZve1BQvef
# QlJHFBDUuwIGZjOrW2pSGBMyMDI0MDUxMjAyNDE0MS4zNzRaMASAAgH0oIHYpIHV
# MIHSMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
# UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMS0wKwYDVQQL
# EyRNaWNyb3NvZnQgSXJlbGFuZCBPcGVyYXRpb25zIExpbWl0ZWQxJjAkBgNVBAsT
# HVRoYWxlcyBUU1MgRVNOOjg2REYtNEJCQy05MzM1MSUwIwYDVQQDExxNaWNyb3Nv
# ZnQgVGltZS1TdGFtcCBTZXJ2aWNloIIRdzCCBycwggUPoAMCAQICEzMAAAHdXVcd
# ldStqhsAAQAAAd0wDQYJKoZIhvcNAQELBQAwfDELMAkGA1UEBhMCVVMxEzARBgNV
# BAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jv
# c29mdCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUtU3RhbXAg
# UENBIDIwMTAwHhcNMjMxMDEyMTkwNzA5WhcNMjUwMTEwMTkwNzA5WjCB0jELMAkG
# A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQx
# HjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEtMCsGA1UECxMkTWljcm9z
# b2Z0IElyZWxhbmQgT3BlcmF0aW9ucyBMaW1pdGVkMSYwJAYDVQQLEx1UaGFsZXMg
# VFNTIEVTTjo4NkRGLTRCQkMtOTMzNTElMCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUt
# U3RhbXAgU2VydmljZTCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAKhO
# A5RE6i53nHURH4lnfKLp+9JvipuTtctairCxMUSrPSy5CWK2DtriQP+T52HXbN2g
# 7AktQ1pQZbTDGFzK6d03vYYNrCPuJK+PRsP2FPVDjBXy5mrLRFzIHHLaiAaobE5v
# FJuoxZ0ZWdKMCs8acjhHUmfaY+79/CR7uN+B4+xjJqwvdpU/mp0mAq3earyH+AKm
# v6lkrQN8zgrcbCgHwsqvvqT6lEFqYpi7uKn7MAYbSeLe0pMdatV5EW6NVnXMYOTR
# KuGPfyfBKdShualLo88kG7qa2mbA5l77+X06JAesMkoyYr4/9CgDFjHUpcHSODuj
# lFBKMi168zRdLerdpW0bBX9EDux2zBMMaEK8NyxawCEuAq7++7ktFAbl3hUKtuzY
# C1FUZuUl2Bq6U17S4CKsqR3itLT9qNcb2pAJ4jrIDdll5Tgoqef5gpv+YcvBM834
# bXFNwytd3ujDD24P9Dd8xfVJvumjsBQQkK5T/qy3HrQJ8ud1nHSvtFVi5Sa/ubGu
# YEpS8gF6GDWN5/KbveFkdsoTVIPo8pkWhjPs0Q7nA5+uBxQB4zljEjKz5WW7BA4w
# pmFm24fhBmRjV4Nbp+n78cgAjvDSfTlA6DYBcv2kx1JH2dIhaRnSeOXePT6hMF0I
# l598LMu0rw35ViUWcAQkUNUTxRnqGFxz5w+ZusMDAgMBAAGjggFJMIIBRTAdBgNV
# HQ4EFgQUbqL1toyPUdpFyyHSDKWj0I4lw/EwHwYDVR0jBBgwFoAUn6cVXQBeYl2D
# 9OXSZacbUzUZ6XIwXwYDVR0fBFgwVjBUoFKgUIZOaHR0cDovL3d3dy5taWNyb3Nv
# ZnQuY29tL3BraW9wcy9jcmwvTWljcm9zb2Z0JTIwVGltZS1TdGFtcCUyMFBDQSUy
# MDIwMTAoMSkuY3JsMGwGCCsGAQUFBwEBBGAwXjBcBggrBgEFBQcwAoZQaHR0cDov
# L3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9jZXJ0cy9NaWNyb3NvZnQlMjBUaW1l
# LVN0YW1wJTIwUENBJTIwMjAxMCgxKS5jcnQwDAYDVR0TAQH/BAIwADAWBgNVHSUB
# Af8EDDAKBggrBgEFBQcDCDAOBgNVHQ8BAf8EBAMCB4AwDQYJKoZIhvcNAQELBQAD
# ggIBAC5U2bINLgXIHWbMcqVuf9jkUT/K8zyLBvu5h8JrqYR2z/eaO2yo1Ooc9Shy
# vxbe9GZDu7kkUzxSyJ1IZksZZw6FDq6yZNT3PEjAEnREpRBL8S+mbXg+O4VLS0LS
# mb8XIZiLsaqZ0fDEcv3HeA+/y/qKnCQWkXghpaEMwGMQzRkhGwcGdXr1zGpQ7HTx
# vfu57xFxZX1MkKnWFENJ6urd+4teUgXj0ngIOx//l3XMK3Ht8T2+zvGJNAF+5/5q
# Bk7nr079zICbFXvxtidNN5eoXdW+9rAIkS+UGD19AZdBrtt6dZ+OdAquBiDkYQ5k
# VfUMKS31yHQOGgmFxuCOzTpWHalrqpdIllsy8KNsj5U9sONiWAd9PNlyEHHbQZDm
# i9/BNlOYyTt0YehLbDovmZUNazk79Od/A917mqCdTqrExwBGUPbMP+/vdYUqaJsp
# upBnUtjOf/76DAhVy8e/e6zR98PkplmliO2brL3Q3rD6+ZCVdrGM9Rm6hUDBBkvY
# h+YjmGdcQ5HB6WT9Rec8+qDHmbhLhX4Zdaard5/OXeLbgx2f7L4QQQj3KgqjqDOW
# InVhNE1gYtTWLHe4882d/k7Lui0K1g8EZrKD7maOrsJLKPKlegceJ9FCqY1sDUKU
# hRa0EHUW+ZkKLlohKrS7FwjdrINWkPBgbQznCjdE2m47QjTbMIIHcTCCBVmgAwIB
# AgITMwAAABXF52ueAptJmQAAAAAAFTANBgkqhkiG9w0BAQsFADCBiDELMAkGA1UE
# BhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAc
# BgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEyMDAGA1UEAxMpTWljcm9zb2Z0
# IFJvb3QgQ2VydGlmaWNhdGUgQXV0aG9yaXR5IDIwMTAwHhcNMjEwOTMwMTgyMjI1
# WhcNMzAwOTMwMTgzMjI1WjB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
# Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
# cmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMDCC
# AiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAOThpkzntHIhC3miy9ckeb0O
# 1YLT/e6cBwfSqWxOdcjKNVf2AX9sSuDivbk+F2Az/1xPx2b3lVNxWuJ+Slr+uDZn
# hUYjDLWNE893MsAQGOhgfWpSg0S3po5GawcU88V29YZQ3MFEyHFcUTE3oAo4bo3t
# 1w/YJlN8OWECesSq/XJprx2rrPY2vjUmZNqYO7oaezOtgFt+jBAcnVL+tuhiJdxq
# D89d9P6OU8/W7IVWTe/dvI2k45GPsjksUZzpcGkNyjYtcI4xyDUoveO0hyTD4MmP
# frVUj9z6BVWYbWg7mka97aSueik3rMvrg0XnRm7KMtXAhjBcTyziYrLNueKNiOSW
# rAFKu75xqRdbZ2De+JKRHh09/SDPc31BmkZ1zcRfNN0Sidb9pSB9fvzZnkXftnIv
# 231fgLrbqn427DZM9ituqBJR6L8FA6PRc6ZNN3SUHDSCD/AQ8rdHGO2n6Jl8P0zb
# r17C89XYcz1DTsEzOUyOArxCaC4Q6oRRRuLRvWoYWmEBc8pnol7XKHYC4jMYcten
# IPDC+hIK12NvDMk2ZItboKaDIV1fMHSRlJTYuVD5C4lh8zYGNRiER9vcG9H9stQc
# xWv2XFJRXRLbJbqvUAV6bMURHXLvjflSxIUXk8A8FdsaN8cIFRg/eKtFtvUeh17a
# j54WcmnGrnu3tz5q4i6tAgMBAAGjggHdMIIB2TASBgkrBgEEAYI3FQEEBQIDAQAB
# MCMGCSsGAQQBgjcVAgQWBBQqp1L+ZMSavoKRPEY1Kc8Q/y8E7jAdBgNVHQ4EFgQU
# n6cVXQBeYl2D9OXSZacbUzUZ6XIwXAYDVR0gBFUwUzBRBgwrBgEEAYI3TIN9AQEw
# QTA/BggrBgEFBQcCARYzaHR0cDovL3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9E
# b2NzL1JlcG9zaXRvcnkuaHRtMBMGA1UdJQQMMAoGCCsGAQUFBwMIMBkGCSsGAQQB
# gjcUAgQMHgoAUwB1AGIAQwBBMAsGA1UdDwQEAwIBhjAPBgNVHRMBAf8EBTADAQH/
# MB8GA1UdIwQYMBaAFNX2VsuP6KJcYmjRPZSQW9fOmhjEMFYGA1UdHwRPME0wS6BJ
# oEeGRWh0dHA6Ly9jcmwubWljcm9zb2Z0LmNvbS9wa2kvY3JsL3Byb2R1Y3RzL01p
# Y1Jvb0NlckF1dF8yMDEwLTA2LTIzLmNybDBaBggrBgEFBQcBAQROMEwwSgYIKwYB
# BQUHMAKGPmh0dHA6Ly93d3cubWljcm9zb2Z0LmNvbS9wa2kvY2VydHMvTWljUm9v
# Q2VyQXV0XzIwMTAtMDYtMjMuY3J0MA0GCSqGSIb3DQEBCwUAA4ICAQCdVX38Kq3h
# LB9nATEkW+Geckv8qW/qXBS2Pk5HZHixBpOXPTEztTnXwnE2P9pkbHzQdTltuw8x
# 5MKP+2zRoZQYIu7pZmc6U03dmLq2HnjYNi6cqYJWAAOwBb6J6Gngugnue99qb74p
# y27YP0h1AdkY3m2CDPVtI1TkeFN1JFe53Z/zjj3G82jfZfakVqr3lbYoVSfQJL1A
# oL8ZthISEV09J+BAljis9/kpicO8F7BUhUKz/AyeixmJ5/ALaoHCgRlCGVJ1ijbC
# HcNhcy4sa3tuPywJeBTpkbKpW99Jo3QMvOyRgNI95ko+ZjtPu4b6MhrZlvSP9pEB
# 9s7GdP32THJvEKt1MMU0sHrYUP4KWN1APMdUbZ1jdEgssU5HLcEUBHG/ZPkkvnNt
# yo4JvbMBV0lUZNlz138eW0QBjloZkWsNn6Qo3GcZKCS6OEuabvshVGtqRRFHqfG3
# rsjoiV5PndLQTHa1V1QJsWkBRH58oWFsc/4Ku+xBZj1p/cvBQUl+fpO+y/g75LcV
# v7TOPqUxUYS8vwLBgqJ7Fx0ViY1w/ue10CgaiQuPNtq6TPmb/wrpNPgkNWcr4A24
# 5oyZ1uEi6vAnQj0llOZ0dFtq0Z4+7X6gMTN9vMvpe784cETRkPHIqzqKOghif9lw
# Y1NNje6CbaUFEMFxBmoQtB1VM1izoXBm8qGCAtMwggI8AgEBMIIBAKGB2KSB1TCB
# 0jELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1Jl
# ZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEtMCsGA1UECxMk
# TWljcm9zb2Z0IElyZWxhbmQgT3BlcmF0aW9ucyBMaW1pdGVkMSYwJAYDVQQLEx1U
# aGFsZXMgVFNTIEVTTjo4NkRGLTRCQkMtOTMzNTElMCMGA1UEAxMcTWljcm9zb2Z0
# IFRpbWUtU3RhbXAgU2VydmljZaIjCgEBMAcGBSsOAwIaAxUANiNHGWXbNaDPxnyi
# DbEOciSjFhCggYMwgYCkfjB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
# Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
# cmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMDAN
# BgkqhkiG9w0BAQUFAAIFAOnqBnEwIhgPMjAyNDA1MTEyMzAwMDFaGA8yMDI0MDUx
# MjIzMDAwMVowczA5BgorBgEEAYRZCgQBMSswKTAKAgUA6eoGcQIBADAGAgEAAgF2
# MAcCAQACAhG1MAoCBQDp61fxAgEAMDYGCisGAQQBhFkKBAIxKDAmMAwGCisGAQQB
# hFkKAwKgCjAIAgEAAgMHoSChCjAIAgEAAgMBhqAwDQYJKoZIhvcNAQEFBQADgYEA
# dAvk0x2sdI7YZNR3ZdCa8gwxbWJm9PVMaK3N7rUBENos6XRsxLr3fQ3iXPz70I9T
# 3SxYh4seYvIGjj3Qfl7Yv64hBAmjE1850BpNvZKgNRppe33rX5UU1DJEpnALiED3
# Yb92kUunmtd24anCj0LKxvHuGpxfkErFpBYAIvDk/XoxggQNMIIECQIBATCBkzB8
# MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVk
# bW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSYwJAYDVQQDEx1N
# aWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMAITMwAAAd1dVx2V1K2qGwABAAAB
# 3TANBglghkgBZQMEAgEFAKCCAUowGgYJKoZIhvcNAQkDMQ0GCyqGSIb3DQEJEAEE
# MC8GCSqGSIb3DQEJBDEiBCDi90KCIOk0rU8IwFVyMrINY3gsGSUaugN33nWayAaH
# pjCB+gYLKoZIhvcNAQkQAi8xgeowgecwgeQwgb0EIGH/Di2aZaxPeJmce0fRWTft
# QI3TaVHFj5GI43rAMWNmMIGYMIGApH4wfDELMAkGA1UEBhMCVVMxEzARBgNVBAgT
# Cldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29m
# dCBDb3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUtU3RhbXAgUENB
# IDIwMTACEzMAAAHdXVcdldStqhsAAQAAAd0wIgQgozGIYWt3MUZ2z8hGWb837/Cc
# gn0x3hTcdYa2nx3ndbEwDQYJKoZIhvcNAQELBQAEggIANyepdzffzsi2iDSWKioq
# jW9+fc+anZzZx23t7jy3g9V56b5agAajfXp00qp602/e+GIdrplKhL1LwxnZmwbo
# unwi8AH+X4JdVpWyyPpHVuOagLGvu1gdlQoRlOHGmX8jgW/ayGy/Pduv2Ot6TlRU
# UAnIYL0W6cqhTbtF9TJD+P5ct5+WJl/pQE/NKKXavIHoeU2YAkP1Rhf2bnqqz/Xf
# rtCoTBJHuUb9AIRQ0RaraB2CbPlsMwiSLLPTveZYPpnfkamQezhn/TBP08xg1MKI
# SJoZx2hH9oobE01uDt8KlzvTSJDZddqbE5b4nO2oXz6ocZ0dMSQCtn+PYjk021LT
# 7oE9YrGkmUuWc5wFSz0CnmnyClrZ/yZmEHmPXv2phbE8Gge1V6JrHm47CI8KYWQq
# /1DEeNSLNZGOt5eNghf2ecEtuPcsvPwIyWYcy789x1gfZPRel14rYwxVGH0uGmaX
# qdxFrDEUVVz0ShZfcif4vbI23KY3sQw2NMLYT5OfHN6aFN99IANkNKLwFcJpyMwZ
# wkar+SmvCLN22JvJLvbJfWAh5RWWrpJPNEIF7/PUXo0zOzGTOqaVKHU0V0XvRjTA
# EjhGwehXKBZiGVIBy2Rq121FTqVITMtAqWqzo0+c3wOit+EkslfIeJJBjT7bW12H
# DbxldbEDLCHP3L8IOkfXJrU=
# SIG # End signature block
