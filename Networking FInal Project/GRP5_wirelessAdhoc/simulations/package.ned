package grp5_wirelessadhoc.simulations;

@license(LGPL);

import inet.networklayer.configurator.ipv4.IPv4NetworkConfigurator;
import inet.node.inet.AdhocHost;
import inet.physicallayer.idealradio.IdealRadioMedium;
import inet.visualizer.contract.IIntegratedVisualizer;

network GRP5_network
{
    parameters:
        int numHosts;
        @display("bgb=600,400");
    submodules:
        visualizer: <default("IntegratedCanvasVisualizer")> like IIntegratedVisualizer if hasVisualizer() {
            parameters:
                @display("p=100,50");
        }
        configurator: IPv4NetworkConfigurator {
            parameters:
                @display("p=100,150");
        }
        radioMedium: IdealRadioMedium {
            parameters:
                @display("p=100,250");
        }
        host[numHosts]: AdhocHost {
            parameters:
                @display("r=,,#707070;p=311,142");
        }
}

