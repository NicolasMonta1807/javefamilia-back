package com.javefamilia.gestionreservas.Mensajeria;

import io.smallrye.reactive.messaging.kafka.api.IncomingKafkaRecordMetadata;
import io.smallrye.reactive.messaging.kafka.api.KafkaMetadataUtil;
import java.util.concurrent.CompletionStage;

import jakarta.ejb.Stateless;
import org.eclipse.microprofile.reactive.messaging.Incoming;
import org.eclipse.microprofile.reactive.messaging.Message;
import jakarta.inject.Inject;
import jakarta.enterprise.context.ApplicationScoped;


@Stateless
public class QueueConsumer {

    @Inject
    private EspacioEventHandler espacioEventHandler;
    @Incoming("espacio-events")
    public CompletionStage<Void> receiveFromKafka(Message<EspacioEvent> message) {
        System.out.println("Prueba de mensaje");
        EspacioEvent payload = message.getPayload();

        System.out.println("Prueba de mensaje 2: " + payload.getClosingTime());

        IncomingKafkaRecordMetadata<Integer, EspacioEvent> md =
                KafkaMetadataUtil.readIncomingKafkaMetadata(message).get();
        String msg =
                "Received from Kafka, storing it in database\n" +
                        "\t%s\n" +
                        "\tkey: %s; partition: %d, topic: %s";
        msg = String.format(msg, payload.getClosingTime(), md.getKey(), md.getPartition(), md.getTopic());

        espacioEventHandler.handleEspacioEvent(payload);

        System.out.println(msg);
        return message.ack();
    }
}