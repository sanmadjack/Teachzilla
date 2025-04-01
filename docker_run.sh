#!/bin/sh
docker run -it --rm -p 8288:8080 --volume /opt/teachzilla:/db --name teachzilla teachzilla
