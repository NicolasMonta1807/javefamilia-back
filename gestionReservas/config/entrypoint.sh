#!/bin/bash

/opt/jboss/wildfly/bin/standalone.sh &

sleep 20

/opt/jboss/wildfly/bin/jboss-cli.sh --connect --controller=localhost:9990 --file=/opt/jboss/wildfly/bin/enable-reactive-messaging.cli
