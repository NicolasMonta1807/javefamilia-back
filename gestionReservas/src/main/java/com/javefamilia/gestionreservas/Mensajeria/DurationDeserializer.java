package com.javefamilia.gestionreservas.Mensajeria;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.JsonDeserializer;
import java.io.IOException;
import java.time.Duration;

public class DurationDeserializer extends JsonDeserializer<Duration> {

    @Override
    public Duration deserialize(JsonParser p, DeserializationContext ctxt) throws IOException {
        String timeString = p.getText().trim();
        // Asumimos que la cadena está en formato "HH:mm:ss"
        String[] parts = timeString.split(":");
        if (parts.length == 2) {
            // Si tiene formato "HH:mm", añadimos segundos por defecto como 00
            timeString += ":00";
            parts = timeString.split(":");
        }
        int hours = Integer.parseInt(parts[0]);
        int minutes = Integer.parseInt(parts[1]);
        int seconds = Integer.parseInt(parts[2]);
        return Duration.ofHours(hours).plusMinutes(minutes).plusSeconds(seconds);
    }
}