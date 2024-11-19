package com.javefamilia.gestionreservas.Security;

import com.azure.identity.ClientSecretCredential;
import com.azure.identity.ClientSecretCredentialBuilder;
import com.azure.security.keyvault.secrets.SecretClient;
import com.azure.security.keyvault.secrets.SecretClientBuilder;
import com.azure.security.keyvault.secrets.models.KeyVaultSecret;
import jakarta.enterprise.context.ApplicationScoped;

public class KeyVaultLoader {

    @ApplicationScoped
        public void loadSecrets() {
        String keyVaultUrl = "https://jf-secrets.vault.azure.net/";
        String clientId = "83ec43c0-fece-43bf-9be5-8c7a0f7c0f71";
        String clientSecret = "VXw8Q~LRzZXqD91czCYUXkCir_v9z1g7mQIIZaMq";
        String tenantId = "69091e3e-f640-4fa8-9dcc-c7b2c9a6238d";

        ClientSecretCredential credential = new ClientSecretCredentialBuilder()
                .clientId(clientId)
                .clientSecret(clientSecret)
                .tenantId(tenantId)
                .build();

        SecretClient secretClient = new SecretClientBuilder()
                .vaultUrl(keyVaultUrl)
                .credential(credential)
                .buildClient();

        KeyVaultSecret dbConnectionString = secretClient.getSecret("EspaciosDatabase--ConnectionString");
        KeyVaultSecret jwtSecret = secretClient.getSecret("JwtSettings--SecretKey");


        System.out.println("Connection String: " + dbConnectionString.getValue());
        System.out.println("JWT Secret Key: " + jwtSecret.getValue());
        }
}