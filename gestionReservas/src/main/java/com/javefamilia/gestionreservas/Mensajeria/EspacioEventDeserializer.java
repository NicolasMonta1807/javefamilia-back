package com.javefamilia.gestionreservas.Mensajeria;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.json.JsonMapper;
import org.apache.kafka.common.serialization.Deserializer;

import java.util.Map;

public class EspacioEventDeserializer implements Deserializer<EspacioEvent> {

    ObjectMapper objectMapper = JsonMapper.builder()
            .findAndAddModules()
            .build();

    @Override
    public void configure(Map<String, ?> configs, boolean isKey) {
        // Configuración si es necesaria
    }

    @Override
    public EspacioEvent deserialize(String topic, byte[] data) {
        if (data == null) {
            return null;
        }

        try {
            // Deserializar el JSON a un objeto EspacioEvent
            return objectMapper.readValue(data, EspacioEvent.class);
        } catch (Exception e) {
            e.printStackTrace();
            throw new RuntimeException("Error deserializando mensaje JSON en EspacioEvent", e);
        }
    }

    @Override
    public void close() {
        // Limpieza si es necesaria
    }
}