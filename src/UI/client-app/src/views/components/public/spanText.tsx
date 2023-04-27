import ISpanText from "../../../types/span";

export const SpanText = ({className, text}: ISpanText) => {
    return <span className={className}>{text}</span>;
};

