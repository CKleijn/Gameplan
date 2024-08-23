type Props = {};

const Spinner: React.FC<Props> = () => {
	return (
		<div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-50 z-50">
			<div className="border-gray-300 h-20 w-20 animate-spin rounded-full border-8 border-t-blue-600"></div>
		</div>
	);
};

export default Spinner;
